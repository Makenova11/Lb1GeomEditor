using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lb1GeomEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics g;

        private Bitmap bpm;

        //Создаём ручку по умолчанию
        private Pen pen = new Pen(color: Color.Aqua);
        private Pen penConture = new Pen(Color.Black);
        private Brush brush = new SolidBrush(Color.Black);

        //Определение состояния фигуры
        private int state = 0;
        private int bitmapState = 0;

        //Линия
        private Point startPoint;
        private Point endPoint;

        //Полилиния
        private List<Point> PolyLinePoints = new List<Point>();
        private int statePolyline = 0;

        //Кривая Безье
        private List<Point> besyePoints = new List<Point>();
        private int statebezye = 0;

        //Полигон
        private List<Point> polyGonPoints = new List<Point>();
        private int statepolygon = 0; //для обработки исключения

        //Прямоугольник. Опорная точка
        private Point rectanglePoint = new Point();

        //Круг, эллипс
        private Point CirclePoint = new Point();
        private bool isMouseDown = false;
        private Pen ellipsePen = new Pen(Color.Black);
        private Brush ellipse = new SolidBrush(Color.Black);

        //Текст
        private Point point = new Point();
        private Font font;


        //Описание состояний state 
        // 1 - выбрана линия, программа считывает значение начальной точки
        // 11 - программа считывает значение конечной точки
        // 111 - программа рисует линию
        // 2 - выбрана линия, на панели ставим точки
        // 3  - выбрана кривая безье
        // 4 - полигон
        // 5 - прямоугольник
        // 6 - круг
        // 7 - эллипс
        // 8 - текстовый блок

        /// <summary>
        /// Выбор цвета для рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                label1.ForeColor = color;
                pen.Color = color;
                brush = new SolidBrush(color);
                ellipse = new SolidBrush(color);
            }
        }


        /// <summary>
        /// Инициализация линии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            state = 1;
            PolylineRadioButton.Visible = false;

            //убираем видимость ненужных элементов
            BezyeRadioButton.Visible = false;
            PolylineRadioButton.Visible = false;
            PolygonradioButton.Visible = false;
            panel2.Visible = false;
            label2.Visible = false;
            ContourButton.Visible = false;
            CounturetrackBar.Visible = false;
            CirclePanel.Visible = false;
        }

        /// <summary>
        /// Сохранение изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Переносим рисунок в созданный Image
            pictureBox1.DrawToBitmap(bpm, pictureBox1.ClientRectangle);

            bpm.Save("image.png",ImageFormat.Png);


            statusStrip1.Text = "Изображение сохранено";

            pictureBox1.Image = Image.FromFile("image.png");
            pictureBox1.Refresh();
            
        }

        /// <summary>
        /// Выбор толщины линии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Задаём значения для trackbar
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 10;

            //Присваиваем pen значения trackbar
            pen.Width = trackBar1.Value;
        }

        /// <summary>
        /// Инициализация полилинии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolyLineButton_CheckedChanged(object sender, EventArgs e)
        {
            state = 2;
            statePolyline = 0;
            PolylineRadioButton.Visible = true;
            BezyeRadioButton.Visible = false;
            BezyeRadioButton.Checked = false;
            CirclePanel.Visible = false;
        }

        /// <summary>
        /// Отрисовка полилинии по точкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolylineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //после отрисовки полилинии radiobutton исчезает
            PolylineRadioButton.Visible = false;
            PolylineRadioButton.Checked = false;
            PolyLineButton.Checked = false;
            if (statePolyline == 0)
            {
                
                g.DrawLines(pen, PolyLinePoints.ToArray());
                g.Save();
                pictureBox1.Refresh();
                PolyLinePoints.Clear();
                
                polyGonPoints = new List<Point>();
                statePolyline = 1;
            }
            
        }

        /// <summary>
        /// Инициализация изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (bitmapState == 0)
            {

                //Создаём Image внутри pictureBox
                bpm = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                ////Создаём объект graphics для рисования на bitmap
                g = Graphics.FromImage(bpm);

                g.Clear(Color.White);
                pictureBox1.Image = bpm;
                bitmapState++;
            }
            

        }

        /// <summary>
        /// При нажатии ЛКМ по pictureBox в зависимости от состояния
        /// происходит считывание значений для отрисовки примитивов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == 1) //line startpoint
            {
                startPoint = new Point(e.X, e.Y);
                state = 11;
            }
            else if (state == 11) //  line endpoint
            {
                endPoint = new Point(e.X, e.Y);
                state = 111;
            }
            else if (state == 2) //polyline
            {

                PolyLinePoints.Add(new Point(e.X, e.Y));
            }
            else if (state == 3) // besyeline
            {
                
                besyePoints.Add(new Point(e.X, e.Y));
            }
            else if (state == 4)//polygon
            {
                polyGonPoints.Add(new Point(e.X,e.Y));
            }
            else if (state == 5)//rectangle
            {
                rectanglePoint = new Point(e.X, e.Y);
            }
            else if (state == 6 || state == 7)//circle, ellipse
            {
                CirclePoint = new Point(e.X, e.Y);
                isMouseDown = true;
            }
            else if (state == 8)//txtBlock
            {
                point = new Point(e.X, e.Y);
            }

        }

        /// <summary>
        ///Отрисовка Линии
        /// Для автоматической отрисовки после отпуска ЛКМ в зависимости
        /// от состояния происходит отрисовка примитива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == 111)
            {
                g.DrawLine(pen, startPoint, endPoint);
                statusStrip1.Text = "Линия нарисована";
            }
            else if (state == 7)
            {
                isMouseDown = false;
            }

            g.Save();
            pictureBox1.Refresh();

        }

        /// <summary>
        /// Инициализация Кривой Безье
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BezyeButtom_CheckedChanged(object sender, EventArgs e)
        {
            state = 3;
            statebezye = 0;
            //убираем видимость ненужных элементов
            BezyeRadioButton.Visible = true;
            PolylineRadioButton.Visible = false;
            PolygonradioButton.Visible = false;
            panel2.Visible = false;
            label2.Visible = false;
            ContourButton.Visible = false;
            CounturetrackBar.Visible = false;
            CirclePanel.Visible = false;
        }

        /// <summary>
        /// Отрисовка Кривой Безье
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BezyeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (statebezye == 0)
            {
                g.DrawBezier(pen, besyePoints[0], besyePoints[1], besyePoints[2], besyePoints[3]);
                g.Save();
                pictureBox1.Refresh();
                BezyeRadioButton.Visible = false;
                BezyeRadioButton.Checked = false;
                besyePoints = new List<Point>();
                statebezye = 1;
            }
        }

        /// <summary>
        /// Инициализация Полигона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Polygon_CheckedChanged(object sender, EventArgs e)
        {
            state = 4;
            statepolygon = 0 ;
            ContourButton.Visible = true;
            PolygonradioButton.Visible = true;
            CounturetrackBar.Visible = true;
            label2.Visible = true;
            CirclePanel.Visible = false;
        }

        /// <summary>
        /// Выбор цвета контура
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContourButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                label2.ForeColor = color;
                penConture.Color = color;
                ellipsePen = new Pen(color);
                //brush = new SolidBrush(color);
            }
        }

        /// <summary>
        /// Выбор толщины контура
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CounturetrackBar_Scroll(object sender, EventArgs e)
        {
            //Задаём значения для trackbar
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 10;

            //Присваиваем pen значения trackbar
            penConture.Width = CounturetrackBar.Value;
        }

        /// <summary>
        /// Отрисовка Полигона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolygonradioButton_CheckedChanged(object sender, EventArgs e)
        {
            ContourButton.Visible = false;
            PolygonradioButton.Visible = false;
            PolygonradioButton.Checked = false;
            CounturetrackBar.Visible = false;
            label2.Visible = false;

            if (statepolygon == 0)
            {
                g.FillPolygon(brush, polyGonPoints.ToArray());
                g.DrawPolygon(penConture, polyGonPoints.ToArray());
                g.Save();
                pictureBox1.Refresh();
                polyGonPoints.Clear();
                
                statepolygon = 1;
            }
        }

        /// <summary>
        /// Инициализация прямоугольника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleButton_CheckedChanged(object sender, EventArgs e)
        {
            state = 5;
            panel2.Visible = true;
            rectanButton.Enabled = false;
            ContourButton.Visible = true;
            PolygonradioButton.Visible = false;
            CounturetrackBar.Visible = true;
            label2.Visible = true;
            CirclePanel.Visible = false;
        }

        /// <summary>
        /// Проверка на внесённые в textbox данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1 is not null & textBox2 is not null)
            {
                rectanButton.Enabled = true;
            }
        }

        /// <summary>
        /// Проверка на внесённые в textbox данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1 is not null & textBox2 is not null)
            {
                rectanButton.Enabled = true;
            }
        }

        /// <summary>
        /// Отрисовка прямоугольника/эллипса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rectanButton_Click(object sender, EventArgs e)
        {
            if (state == 5)
            {
                int height = Convert.ToInt32(textBox1.Text);
                int widht = Convert.ToInt32(textBox2.Text);
                Rectangle rectangle = new Rectangle(rectanglePoint, new Size(widht, height));
                
                g.DrawRectangle(penConture, rectangle);
                g.FillRectangle(brush, rectangle);
                g.Save();
                pictureBox1.Refresh();
            }
            else if (state == 7)
            {
                int height = Convert.ToInt32(textBox1.Text);
                int width = Convert.ToInt32(textBox2.Text);
                Size size = new Size(width, height);
                CirclePoint.X -= width / 2;
                CirclePoint.Y -= height / 2;
                Rectangle rectangle = new Rectangle(CirclePoint, size);

                g.DrawEllipse(ellipsePen, rectangle);
                
                g.FillEllipse(ellipse, rectangle);
                g.Save();
                pictureBox1.Refresh();
            }
            g.Save();
            pictureBox1.Refresh();

            //убираем видимость панели инструментов для прямоугольника
            panel2.Visible = false;
            ContourButton.Visible = false;
            PolygonradioButton.Visible = false;
            CounturetrackBar.Visible = false;
            label2.Visible = false;
            CirclePanel.Visible = false;
        }

        /// <summary>
        /// Открытие изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    bpm = new Bitmap(open_dialog.FileName);
                    this.pictureBox1.Size = bpm.Size;
                    pictureBox1.Image = bpm;
                    g = Graphics.FromImage(bpm);
                    g.Save();
                    pictureBox1.Refresh();
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Инициализация круга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircleButton_CheckedChanged(object sender, EventArgs e)
        {
            state = 6;
            CirclePanel.Visible = true;

            //убираем видимость ненужных элементов
            BezyeRadioButton.Visible = false;
            PolylineRadioButton.Visible = false;
            PolygonradioButton.Visible = false;

            panel2.Visible = false;
            label2.Visible = true;
            ContourButton.Visible = true;
            CounturetrackBar.Visible = true;
        }

        /// <summary>
        /// Отрисовка круга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int radius = Convert.ToInt32(textBox3.Text);
            Size size = new Size(radius, radius);
            CirclePoint.X -= radius / 2;
            CirclePoint.Y -= radius / 2;
            Rectangle rectangle = new Rectangle(CirclePoint, size);
            g.DrawEllipse(pen, rectangle);
            g.FillEllipse(brush,rectangle);

            g.Save();
            pictureBox1.Refresh();
            
            //Убираем видимость
            panel2.Visible = false;
            ContourButton.Visible = false;
            PolygonradioButton.Visible = false;
            CounturetrackBar.Visible = false;
            label2.Visible = false;
            CirclePanel.Visible = false;
            BezyeRadioButton.Visible = false;
            PolylineRadioButton.Visible = false;
            PolygonradioButton.Visible = false;
        }

        /// <summary>
        /// Инициализация эллипса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EllipsButton_CheckedChanged(object sender, EventArgs e)
        {
            state = 7;

            BezyeRadioButton.Visible = false;
            PolylineRadioButton.Visible = false;
            PolygonradioButton.Visible = false;
            panel2.Visible = true;
            rectanButton.Enabled = false;
            ContourButton.Visible = true;
            CounturetrackBar.Visible = true;
            label2.Visible = true;
            CirclePanel.Visible = false;
        }

        /// <summary>
        /// Инициализация текстового блока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextButton_CheckedChanged(object sender, EventArgs e)
        {
            state = 8;
            FontBtn.Visible = true;
            CreateTXT.Enabled = false;
            txtPanel.Visible = true;

            label2.Visible = true;
            CounturetrackBar.Visible = true;
            ContourButton.Visible = true;
        }

        /// <summary>
        /// Выбор шрифта, его размера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontBtn_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size);
            }
            
        }
        /// <summary>
        /// Отрисовка текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateTXT_Click(object sender, EventArgs e)
        {
            g.DrawString(textBox4.Text,font, brush, point);
            g.Save();
            pictureBox1.Refresh();

            label2.Visible = false;
            CounturetrackBar.Visible = false;
            ContourButton.Visible = false;
        }

        /// <summary>
        /// Проверка условия на пустое поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4 != null)
            {
                CreateTXT.Enabled = true;
            }
        }

        /// <summary>
        /// CОХРАНЕНИЕ SVG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Переносим рисунок в созданный Image
            pictureBox1.DrawToBitmap(bpm, pictureBox1.ClientRectangle);
           
            bpm.Save("imageSVG.wmf", ImageFormat.Wmf);

            statusStrip1.Text = "Изображение сохранено";


        }


        /// <summary>
        /// Создание массовых эллипсов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (state == 7 && isMouseDown == true)
            {
                int height = Convert.ToInt32(textBox1.Text);
                int width = Convert.ToInt32(textBox2.Text);
                Size size = new Size(width, height);
                CirclePoint.X -= width / 2;
                CirclePoint.Y -= height / 2;
                Rectangle rectangle = new Rectangle(new Point(e.X, e.Y), size);
                g.DrawEllipse(pen, rectangle);
                System.Threading.Thread.Sleep(100);
                //g.FillEllipse(ellipse, rectangle);
                g.Save();
                pictureBox1.Refresh();
            }
        }
    }
}
