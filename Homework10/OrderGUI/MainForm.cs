using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF;

namespace OrderGUI
{
    public partial class MainForm : Form
    {
        public OrderService orderService = new OrderService();
        public MainForm()
        {
            InitializeComponent();
            OrderBindingsource.DataSource = orderService.GetAllOrders(); //初始化
        }

        private void CheckGridView()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:OrderBindingsource.DataSource = orderService.GetAllOrders();
                    break;
                case 1:OrderBindingsource.DataSource = orderService.GetOrder(textBox1.Text);
                    break;
                case 2:OrderBindingsource.DataSource = orderService.QueryByCustormer(textBox1.Text);
                    break;
                case 3:OrderBindingsource.DataSource = orderService.QueryByGoods(textBox1.Text);
                    break;
                default: OrderBindingsource.DataSource = orderService.GetAllOrders();break;
            }
            OrderBindingsource.ResetBindings(false);
            OrderDetailsBindingsource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(null);
            editForm.ShowDialog();
            CheckGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OrderBindingsource.Current != null)
            {
                EditForm editForm = new EditForm((Order)OrderBindingsource.Current);
                editForm.ShowDialog();
                CheckGridView();
            }
            else
            {
                MessageBox.Show("没有选择数据！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OrderBindingsource.Current != null)
            {
                Order order = (Order)OrderBindingsource.Current;
                orderService.Delete(order.Id);
                CheckGridView();
            }
            else
            {
                MessageBox.Show("没有选择数据！");
            }
        }
    }
}
