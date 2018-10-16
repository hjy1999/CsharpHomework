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

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (0 == n) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void OtherdrawCayleyTree(int n, double y0, double x0, double leng, double th)
        {
            if (0 == n) return;
            double y1 = y0 + leng * Math.Sin(th);
            double x1 = x0 + leng * Math.Cos(th);
            OtherdrawLine(y0, x0, y1, x1);
            OtherdrawCayleyTree(n - 1, y1, x1, per1 * leng, th + th1);
            OtherdrawCayleyTree(n - 1, y1, x1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        void OtherdrawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x1, (int)y1, (int)x0, (int)y0);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            OtherdrawCayleyTree(10, 450, 310, 100, -Math.PI / 2);
        }
    }
}
