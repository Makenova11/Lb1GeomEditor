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

        //Кривая Безье
        private List<Point> besyePoints = new List<Point>();

        //Полигон
        private List<Point> polyGonPoints = new List<Point>();

        //Прямоугольник. Опорная точка
        private Point rectanglePoint = new Point();

        //Описание состояний state 
        // 1 - выбрана линия, программа считывает значение начальной точки
        // 11 - программа считывает значение конечной точки
        // 111 - программа рисует линию
        // 2 - выбрана линия, на панели ставим точки
        // 3  - выбрана кривая безье
        // 4 - полигон
        // 5 - прямоугольник

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
            PolylineRadioButton.Visible = true;
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

            g.DrawLines(pen, PolyLinePoints.ToArray());
            pictureBox1.Refresh();
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
            BezyeRadioButton.Visible = true;
            PolylineRadioButton.Visible = false;

        }

        /// <summary>
        /// Отрисовка Кривой Безье
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BezyeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            g.DrawBezier(pen,besyePoints[0],besyePoints[1],besyePoints[2],besyePoints[3]);
            g.Save();
            pictureBox1.Refresh();
            BezyeRadioButton.Visible = false;
        }

        /// <summary>
        /// Инициализация Полигона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Polygon_CheckedChanged(object sender, EventArgs e)
        {
            state = 4;
            ContourButton.Visible = true;
            PolygonradioButton.Visible = true;
            CounturetrackBar.Visible = true;
            label2.Visible = true;
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

            g.FillPolygon(brush, polyGonPoints.ToArray());
            g.DrawPolygon(penConture, polyGonPoints.ToArray());
            g.Save();
            pictureBox1.Refresh();
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
            PolygonradioButton.Visible = true;
            CounturetrackBar.Visible = true;
            label2.Visible = true;
        }

        /// <summary>
        /// Проверка на внесённые в textbox данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1 is not null && textBox2 is not null)
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
            if (textBox1 is not null && textBox2 is not null)
            {
                rectanButton.Enabled = true;
            }
        }

        /// <summary>
        /// Отрисовка прямоугольника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rectanButton_Click(object sender, EventArgs e)
        {

        }
    }
}
