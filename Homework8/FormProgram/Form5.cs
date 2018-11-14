using System;
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
    public partial class Form5 : Form
    {
        public Form1 f1;
        public List<Order> person5 = new List<Order>();
        public Form5(Form1 f1)
        {
            this.f1 = f1;
            person5 = Form1.person;
            InitializeComponent();
            foreach (Order n in person5)
            {
                if (n.Name == f1.textBox1.Text)
                {
                    foreach (OrderDetails m in n.Items)
                    {
                        comboBox1.Items.Add(m.Product);
                    }
                }
                
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Order n in person5)
            {
                foreach (OrderDetails m in n.Items)
                {
                    if (m.Product == comboBox1.Text)
                    {
                        m.Product = textBox1.Text;
                        m.Num = textBox2.Text;
                        m.Price = Convert.ToDouble(textBox3.Text);
                        break;
                    }
                }
            }
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }
    }
}
