
namespace Lb1GeomEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColourButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LineButton = new System.Windows.Forms.RadioButton();
            this.PolyLineButton = new System.Windows.Forms.RadioButton();
            this.BezyeButtom = new System.Windows.Forms.RadioButton();
            this.Polygon = new System.Windows.Forms.RadioButton();
            this.RectangleButton = new System.Windows.Forms.RadioButton();
            this.CircleButton = new System.Windows.Forms.RadioButton();
            this.EllipsButton = new System.Windows.Forms.RadioButton();
            this.TextButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BezyeRadioButton = new System.Windows.Forms.RadioButton();
            this.SaveButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.PolylineRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rectanButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PolygonradioButton = new System.Windows.Forms.RadioButton();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.ContourButton = new System.Windows.Forms.Button();
            this.CounturetrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CounturetrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(441, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(767, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ColourButton
            // 
            this.ColourButton.Location = new System.Drawing.Point(20, 25);
            this.ColourButton.Name = "ColourButton";
            this.ColourButton.Size = new System.Drawing.Size(116, 29);
            this.ColourButton.TabIndex = 1;
            this.ColourButton.Text = "Цвет заливки";
            this.ColourButton.UseVisualStyleBackColor = true;
            this.ColourButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Цвет";
            // 
            // LineButton
            // 
            this.LineButton.AutoSize = true;
            this.LineButton.Location = new System.Drawing.Point(23, 26);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(75, 24);
            this.LineButton.TabIndex = 3;
            this.LineButton.TabStop = true;
            this.LineButton.Text = "Линия";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // PolyLineButton
            // 
            this.PolyLineButton.AutoSize = true;
            this.PolyLineButton.Location = new System.Drawing.Point(23, 56);
            this.PolyLineButton.Name = "PolyLineButton";
            this.PolyLineButton.Size = new System.Drawing.Size(110, 24);
            this.PolyLineButton.TabIndex = 4;
            this.PolyLineButton.TabStop = true;
            this.PolyLineButton.Text = "Полилиния";
            this.PolyLineButton.UseVisualStyleBackColor = true;
            this.PolyLineButton.CheckedChanged += new System.EventHandler(this.PolyLineButton_CheckedChanged);
            // 
            // BezyeButtom
            // 
            this.BezyeButtom.AutoSize = true;
            this.BezyeButtom.Location = new System.Drawing.Point(23, 86);
            this.BezyeButtom.Name = "BezyeButtom";
            this.BezyeButtom.Size = new System.Drawing.Size(125, 24);
            this.BezyeButtom.TabIndex = 5;
            this.BezyeButtom.TabStop = true;
            this.BezyeButtom.Text = "Кривая Безье";
            this.BezyeButtom.UseVisualStyleBackColor = true;
            this.BezyeButtom.CheckedChanged += new System.EventHandler(this.BezyeButtom_CheckedChanged);
            // 
            // Polygon
            // 
            this.Polygon.AutoSize = true;
            this.Polygon.Location = new System.Drawing.Point(23, 116);
            this.Polygon.Name = "Polygon";
            this.Polygon.Size = new System.Drawing.Size(91, 24);
            this.Polygon.TabIndex = 6;
            this.Polygon.TabStop = true;
            this.Polygon.Text = "Полигон";
            this.Polygon.UseVisualStyleBackColor = true;
            this.Polygon.CheckedChanged += new System.EventHandler(this.Polygon_CheckedChanged);
            // 
            // RectangleButton
            // 
            this.RectangleButton.AutoSize = true;
            this.RectangleButton.Location = new System.Drawing.Point(23, 146);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(141, 24);
            this.RectangleButton.TabIndex = 7;
            this.RectangleButton.TabStop = true;
            this.RectangleButton.Text = "Прямоугольник";
            this.RectangleButton.UseVisualStyleBackColor = true;
            this.RectangleButton.CheckedChanged += new System.EventHandler(this.RectangleButton_CheckedChanged);
            // 
            // CircleButton
            // 
            this.CircleButton.AutoSize = true;
            this.CircleButton.Location = new System.Drawing.Point(23, 176);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(61, 24);
            this.CircleButton.TabIndex = 8;
            this.CircleButton.TabStop = true;
            this.CircleButton.Text = "Круг";
            this.CircleButton.UseVisualStyleBackColor = true;
            // 
            // EllipsButton
            // 
            this.EllipsButton.AutoSize = true;
            this.EllipsButton.Location = new System.Drawing.Point(23, 206);
            this.EllipsButton.Name = "EllipsButton";
            this.EllipsButton.Size = new System.Drawing.Size(80, 24);
            this.EllipsButton.TabIndex = 9;
            this.EllipsButton.TabStop = true;
            this.EllipsButton.Text = "Эллипс";
            this.EllipsButton.UseVisualStyleBackColor = true;
            // 
            // TextButton
            // 
            this.TextButton.AutoSize = true;
            this.TextButton.Location = new System.Drawing.Point(23, 236);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new System.Drawing.Size(66, 24);
            this.TextButton.TabIndex = 10;
            this.TextButton.TabStop = true;
            this.TextButton.Text = "Текст";
            this.TextButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LineButton);
            this.groupBox1.Controls.Add(this.PolyLineButton);
            this.groupBox1.Controls.Add(this.BezyeButtom);
            this.groupBox1.Controls.Add(this.TextButton);
            this.groupBox1.Controls.Add(this.Polygon);
            this.groupBox1.Controls.Add(this.EllipsButton);
            this.groupBox1.Controls.Add(this.RectangleButton);
            this.groupBox1.Controls.Add(this.CircleButton);
            this.groupBox1.Location = new System.Drawing.Point(2, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 273);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // BezyeRadioButton
            // 
            this.BezyeRadioButton.AutoSize = true;
            this.BezyeRadioButton.Location = new System.Drawing.Point(159, 120);
            this.BezyeRadioButton.Name = "BezyeRadioButton";
            this.BezyeRadioButton.Size = new System.Drawing.Size(213, 24);
            this.BezyeRadioButton.TabIndex = 11;
            this.BezyeRadioButton.TabStop = true;
            this.BezyeRadioButton.Text = "Нарисовать кривую Безье";
            this.BezyeRadioButton.UseVisualStyleBackColor = true;
            this.BezyeRadioButton.Visible = false;
            this.BezyeRadioButton.CheckedChanged += new System.EventHandler(this.BezyeRadioButton_CheckedChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(223, 25);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(138, 29);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1220, 26);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel1.Text = "Состояние";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(29, 74);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(130, 56);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // PolylineRadioButton
            // 
            this.PolylineRadioButton.AutoSize = true;
            this.PolylineRadioButton.Location = new System.Drawing.Point(159, 90);
            this.PolylineRadioButton.Name = "PolylineRadioButton";
            this.PolylineRadioButton.Size = new System.Drawing.Size(199, 24);
            this.PolylineRadioButton.TabIndex = 11;
            this.PolylineRadioButton.TabStop = true;
            this.PolylineRadioButton.Text = "Нарисовать полилинию";
            this.PolylineRadioButton.UseVisualStyleBackColor = true;
            this.PolylineRadioButton.Visible = false;
            this.PolylineRadioButton.CheckedChanged += new System.EventHandler(this.PolylineRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.PolygonradioButton);
            this.panel1.Controls.Add(this.BezyeRadioButton);
            this.panel1.Controls.Add(this.PolylineRadioButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(10, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 332);
            this.panel1.TabIndex = 16;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rectanButton);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(220, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 102);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
            // 
            // rectanButton
            // 
            this.rectanButton.Location = new System.Drawing.Point(23, 63);
            this.rectanButton.Name = "rectanButton";
            this.rectanButton.Size = new System.Drawing.Size(108, 29);
            this.rectanButton.TabIndex = 4;
            this.rectanButton.Text = "Нарисовать ";
            this.rectanButton.UseVisualStyleBackColor = true;
            this.rectanButton.Click += new System.EventHandler(this.rectanButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ширина";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Высота";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(89, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(58, 27);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PolygonradioButton
            // 
            this.PolygonradioButton.AutoSize = true;
            this.PolygonradioButton.Location = new System.Drawing.Point(159, 150);
            this.PolygonradioButton.Name = "PolygonradioButton";
            this.PolygonradioButton.Size = new System.Drawing.Size(178, 24);
            this.PolygonradioButton.TabIndex = 11;
            this.PolygonradioButton.TabStop = true;
            this.PolygonradioButton.Text = "Нарисовать Полигон";
            this.PolygonradioButton.UseVisualStyleBackColor = true;
            this.PolygonradioButton.Visible = false;
            this.PolygonradioButton.CheckedChanged += new System.EventHandler(this.PolygonradioButton_CheckedChanged);
            // 
            // ContourButton
            // 
            this.ContourButton.Location = new System.Drawing.Point(223, 74);
            this.ContourButton.Name = "ContourButton";
            this.ContourButton.Size = new System.Drawing.Size(138, 31);
            this.ContourButton.TabIndex = 11;
            this.ContourButton.Text = "Цвет контура";
            this.ContourButton.UseVisualStyleBackColor = true;
            this.ContourButton.Visible = false;
            this.ContourButton.Click += new System.EventHandler(this.ContourButton_Click);
            // 
            // CounturetrackBar
            // 
            this.CounturetrackBar.Location = new System.Drawing.Point(223, 120);
            this.CounturetrackBar.Name = "CounturetrackBar";
            this.CounturetrackBar.Size = new System.Drawing.Size(138, 56);
            this.CounturetrackBar.TabIndex = 17;
            this.CounturetrackBar.Visible = false;
            this.CounturetrackBar.Scroll += new System.EventHandler(this.CounturetrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Цвет";
            this.label2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CounturetrackBar);
            this.Controls.Add(this.ContourButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColourButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CounturetrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColourButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton LineButton;
        private System.Windows.Forms.RadioButton PolyLineButton;
        private System.Windows.Forms.RadioButton BezyeButtom;
        private System.Windows.Forms.RadioButton Polygon;
        private System.Windows.Forms.RadioButton RectangleButton;
        private System.Windows.Forms.RadioButton CircleButton;
        private System.Windows.Forms.RadioButton EllipsButton;
        private System.Windows.Forms.RadioButton TextButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.RadioButton PolylineRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton BezyeRadioButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button ContourButton;
        private System.Windows.Forms.TrackBar CounturetrackBar;
        private System.Windows.Forms.RadioButton PolygonradioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button rectanButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

