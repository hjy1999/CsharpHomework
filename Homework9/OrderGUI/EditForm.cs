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

    public partial class EditForm : Form
    {
        public OrderService orderService = new OrderService();
        bool addMode = false;
        public Order tempOrder { get; set; }

        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(Order order) : this()
        {
            if (order == null)
            {
                addMode = true;
                tempOrder = new Order();
            }
            else
            {
                tempOrder = order;
            }
            bindingSource1.DataSource = tempOrder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (addMode)
            {
                orderService.Add(tempOrder);
            }
            else
            {
                orderService.Update(tempOrder);
            }
            this.Close();
        }
    }
}
