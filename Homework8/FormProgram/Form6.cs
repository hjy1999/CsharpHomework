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
    public partial class Form6 : Form
    {
        public Form1 f1;
        public List<Order> person6 = new List<Order>();
        public Form6(Form1 f1)
        {
            this.f1 = f1;
            InitializeComponent();
            person6 = Form1.person;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> temp = new List<Order>();
            temp = person6;
            for(int j=0;j<temp.Count;j++)
            {
                int k = temp[j].Items.Count;
                int i = 0;
                for(int m=k;m>0;m--)
                {
                    if (temp[j].Items[i].Price <= Convert.ToDouble(textBox1.Text) || temp[j].Items[i].Price >= Convert.ToDouble(textBox2.Text))
                    {
                        temp[j].Items.Remove(temp[j].Items[i]);
                        i--;
                    }
                    i++;
                }
            }
            f1.OrderBindingSource.DataSource = temp;
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }
    }
}
