﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program1;

namespace FormProgram
{
    public partial class Form2 : Form
    {
        public Form1 f1;
        public List<Order> person2 = new List<Order>();
        public Form2(Form1 f1)
        {
            this.f1 = f1;
            InitializeComponent();
            person2 = Form1.person;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Order n in person2)
            {
                if (n.Name == f1.textBox1.Text)
                {
                    n.Items.Add(new OrderDetails(textBox2.Text, textBox1.Text, Convert.ToDouble(textBox3.Text)));
                    break;
                }
            }

            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
