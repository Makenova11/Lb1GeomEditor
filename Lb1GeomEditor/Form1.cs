using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private Point startXY = new Point(4,3);
        private Point endXY = new Point(2,1);
        private bool ismouseDown = false;
        private Color color = new Color();
        private Pen pen = new Pen(color: Color.Aqua);
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                label1.ForeColor = color;
                pen.Color = color;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismouseDown == true)
            {
                endXY = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            endXY = e.Location;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startXY = e.Location;
            ismouseDown = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {//создать кнопку для прямоугольника(или радиобаттоны) и активные поля числовые (bool)

            //mouseup берет значение из кнопки типа фигуры и в зависимости от значения,
            //рисует в месте нажатия мышки нужную фигуру
            e.Graphics.DrawRectangle(pen,Math.Min(startXY.X, endXY.X), Math.Min(startXY.Y, endXY.Y),
                Math.Abs(endXY.X-startXY.X), Math.Abs(endXY.Y - startXY.Y));
        }
    }
}
