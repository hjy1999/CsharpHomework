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
        }

        public List<Order> Opfile()
        {
            return OrderService.Import("D:\\CSharpText\\Homework5", "D:\\CSharpText\\Homework5\\order.xml"); 
        }

        public void Import(List<Order> temp)
        {
            OrderService.Export("D:\\CSharpText\\Homework5", "D:\\CSharpText\\Homework5\\order.xml",temp);
        }

        public void openForm2()
        {
            Form2 myForm = new Form2(this);
            myForm.ShowDialog();
        }

        public void openForm3()
        {
            Form3 myForm = new Form3(this);
            myForm.ShowDialog();
        }

        public void openForm5()
        {
            Form5 myForm = new Form5(this);
            myForm.ShowDialog();
        }

        public void openForm6()
        {
            Form6 myForm = new Form6(this);
            myForm.ShowDialog();
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect)
            {
                int index = dataGridView1.CurrentRow.Index; 
                textBox1.Text = dataGridView1.Rows[index].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            };
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect)
            {
                int index = dataGridView1.CurrentRow.Index; 
                textBox3.Text = dataGridView1.Rows[index].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            };
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect)
            {
                comboBox4.Items.Clear();
                int i = 0;
                while (i < dataGridView2.RowCount)
                {
                    comboBox4.Items.Add(dataGridView2.Rows[i].Cells["productDataGridViewTextBoxColumn"].Value.ToString());
                    i++;
                }
            };
            label3.Text = "共"+dataGridView2.RowCount+"条记录";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OrderBindingSource.DataSource = person.Where(n => n.Name == textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person = Opfile();
            person.Add(OrderService.Addway(textBox1.Text, textBox3.Text));
            //Import(person);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var temp = person.Where(n => n.Name == textBox1.Text || n.Clent == textBox3.Text);
            foreach(Order n in temp)
            {
                person.Remove(n);
                break;
            }
            //Import(person);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            openForm5();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openForm2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openForm3();
        }

        private void button7_Click(object sender, EventArgs e)    //回到初始状态
        {
            person = OrderService.otherImporway(openFileDialog1.FileName);
            OrderBindingSource.DataSource = person;
        }

        private void button8_Click(object sender, EventArgs e)  //保存文件
        {
            Import(person);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openForm6();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            person = OrderService.otherImporway(openFileDialog1.FileName);
            OrderBindingSource.DataSource = person;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            OrderService.otherExportway(saveFileDialog1.FileName, person);
        }

    }
}
