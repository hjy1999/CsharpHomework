using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        double temp1 = 30;
        double temp2 = 20;
        int LineWidth;
        private Graphics graphics;
        //double th1 = temp1 * Math.PI / 180;
        //double th2 = temp2 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (0 == n) return;

            double th1 = temp1 * Math.PI / 180;
            double th2 = temp2 * Math.PI / 180;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            if (radioButton1.Checked)
            {
                Pen Temp = new Pen(Color.Blue, LineWidth);
                graphics.DrawLine(Temp, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if (radioButton2.Checked)
            {
                Pen Temp = new Pen(Color.Green, LineWidth);
                graphics.DrawLine(Temp, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if (radioButton3.Checked)
            {
                Pen Temp = new Pen(Color.Red, LineWidth);
                graphics.DrawLine(Temp, (int)x0, (int)y0, (int)x1, (int)y1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { LineWidth = Convert.ToInt32(textBox1.Text); }
            catch { Console.WriteLine("请输入正确的数字"); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { temp1 = Convert.ToDouble(textBox2.Text); }
            catch { Console.WriteLine("请输入正确的数字"); }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { temp2 = Convert.ToDouble(textBox3.Text); }
            catch { Console.WriteLine("请输入正确的数字"); }
        }
    }
}
