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
    public partial class Form3 : Form
    {
        public Form1 f1;
        public List<Order> person3 = new List<Order>();
        public Form3(Form1 f1)
        {
            this.f1 = f1;
            InitializeComponent();
            person3 = Form1.person;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Order n in person3)
            {
                if (n.Name == f1.textBox1.Text)
                {
                    var search = n.Items.First(m => m.Product == textBox1.Text);
                    n.Items.Remove(search);
                    break;
                }
            }
            //f1.Import(person3);
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }
    }
}
