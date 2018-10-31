using program1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace FormProgram
{
    public partial class Form1 : Form
    {
        public static List<Order> person = new List<Order>();
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();

            person = OrderService.Import("D:\\CSharpText\\Homework5", "D:\\CSharpText\\Homework5\\order.xml"); //!
            OrderBindingSource.DataSource = person; 
        }
        private void reBindingSource()
        {
            OrderBindingSource.DataSource = person;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OrderBindingSource.DataSource = person.Where(n => n.Name == textBox1.Text);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.Add(OrderService.Addway(textBox1.Text, textBox3.Text)); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var temp = person.Where(n => n.Name == textBox1.Text || n.Clent == textBox3.Text);
            foreach(Order n in temp)
            {
                person.Remove(n);
                break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IEnumerable<Order> temp = new List<Order>();
            temp = OrderService.SearchAllOrder(Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox6.Text),person);
            OrderBindingSource.DataSource = temp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var search = OrderService.IntoOrder(textBox1.Text, person);
            OrderService.IntoOrderAdd(textBox4.Text, textBox9.Text, Convert.ToDouble(textBox5.Text), search);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reBindingSource();
        }
    }
}
