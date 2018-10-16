using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class OrderService : Order
    {
        public static List<Order> data;

        public static void Addway()
        {
            Console.WriteLine("请输入订单名称");
            var name = Console.ReadLine();
            Console.WriteLine("请输入订单编号");
            var clent = Console.ReadLine();
            Order person = new Order(name, clent);
            Console.WriteLine("进入订单!");
            bool temp = true;
            while (temp)
            {
                Console.WriteLine("输入1继续添加条目，输入0停止添加并返回菜单");
                int S = Convert.ToInt32(Console.ReadLine());
                switch (S)
                {
                    case 1:
                        {
                            Console.WriteLine("请输入商品种类");
                            String product = Console.ReadLine();
                            Console.WriteLine("请输入商品数量");
                            String num = Console.ReadLine();
                            Console.WriteLine("请输入商品单价");
                            String PRICE = Console.ReadLine();
                            double price = Convert.ToDouble(PRICE);
                            OrderDetails person2 = new OrderDetails(num, product, price);
                            person.Items.Add(person2);
                            break;
                        }
                    case 0:
                        {
                            temp = false;
                            break;
                        }
                }
            }
            data.Add(person);

        }
        public static void Deleteway()
        {
            Console.WriteLine("输入想要删除的订单编号或名称");
            string temp = Console.ReadLine();
            var search = data.Where(a => a.Name == temp || a.Clent == temp);
            foreach (Order n in search.ToList())
            {
                data.Remove(n);
            }
        }

        public void Searchway()
        {
            Console.WriteLine("请输入要查找的订单");
            string temp = Console.ReadLine();
            var search = data.Where(a => a.Clent == temp || a.Name == temp);
            foreach (Order n in search.ToList())
            {
                Console.WriteLine("订单名:" + n.Name + "订单号" + n.Clent);
                for (int i = 0; i < n.Items.Count; i++)
                {
                    Console.WriteLine("       数量:" + n.Items[i].Num + "产品:" + n.Items[i].Product + "单价:" + n.Items[i].Price);
                }
            }
        }

        public void Showway()
        {
            int i = 0;
            while (i < data.Count)
            {
                Console.WriteLine("订单名:" + data[i].Name + "订单号:" + data[i].Clent);
                for (int j = 0; j < data[i].Items.Count; j++)
                {
                    Console.WriteLine("        数量:" + data[i].Items[j].Num + "产品:" + data[i].Items[j].Product + "单价:" + data[i].Items[j].Price);
                }
                i++;
            }
        }

        public void Checkway()
        {
            Console.WriteLine("请输入要查找的订单");
            string temp = Console.ReadLine();
            var Check = data.Where(a => a.Name == temp || a.Clent == temp);
            Console.WriteLine("输入价钱");
            string Temp = Console.ReadLine();
            double PRICE = Convert.ToDouble(Temp);
            foreach (Order n in Check)
            {
                var Check2 = n.Items.Where(a => a.Price <= PRICE);
                Console.WriteLine("姓名：" + n.Name + "订单号：" + n.Clent);
                foreach (OrderDetails m in Check2)
                {
                    Console.WriteLine("  产品：" + m.Product + "数量：" + m.Num + "单价：" + m.Price);
                }
            }
        }

        public void InDetails()
        {

        }

        public OrderService()
        {

            bool A = false;
            while (true != A)
            {
                Console.WriteLine("输入1：添加订单 2：删除订单 3:查找订单 4：输出订单 5:筛选价格 -1：结束");
                int B = Convert.ToInt32(Console.ReadLine());
                switch (B)
                {
                    case 1:
                        {
                            Addway();
                            break;
                        }
                    case 2:
                        {
                            Deleteway();
                            break;
                        }
                    case 3:
                        {
                            Searchway();
                            break;
                        }
                    case 4:
                        {
                            Showway();
                            break;
                        }
                    case 5:
                        {
                            Checkway();
                            break;
                        }
                    case -1:
                        {
                            A = true;
                            break;
                        }
                }
            }
        }
    }
}
