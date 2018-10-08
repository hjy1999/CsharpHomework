using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    using System;
    public class OrderService
    {
        public string name;
        public string num;
        public string product;
        public OrderService() { }
        public OrderService(string Name, string Num, string Product)
        {
            name = Name; num = Num; product = Product;
        }
        public static List<OrderService> date = new List<OrderService>();

    }

    public class Order : OrderService
    {
        public void ListAddWay(OrderService n)
        {
            date.Add(n);
        }
        public OrderService AddWay(string A, string B, string C)
        {
            OrderService temp = new OrderService(A, B, C);
            Order e = new Order();
            e.ListAddWay(temp);
            return temp;
        }
        public void RemoveWay(string temp)
        {
            int i = 0;
            while (i < date.Count)
            {
                if (temp == date[i].name || temp == date[i].num || temp == date[i].product)
                {
                    date.RemoveAt(i);
                }
                i++;
            }
        }
        public void ReviseWay(string A, string B)
        {
            int i = 0;
            while (i < date.Count)
            {
                if (A == date[i].name)
                {
                    date[i].name = B;
                }
                else if (A == date[i].num)
                {
                    date[i].num = B;
                }
                else if (A == date[i].product)
                {
                    date[i].product = B;
                }
                i++;
            }
        }
        public void CheckWay(string temp)//查询订单
        {
            bool search = false;
            for (int i = 0; i < date.Count; i++)
            {
                if (temp == date[i].name || temp == date[i].num || temp == date[i].product)
                {
                    search = true;
                    Console.WriteLine("Name:" + date[i].name + "  Num:" + date[i].num + "  Product:" + date[i].product);
                }
            }
            if (search == false)
                Console.WriteLine("没有找到数据");
        }
    }

    public class menu : OrderService
    {
        public void ShowMenu()
        {
            Console.WriteLine("输入1:添加订单 2:删除某订单 3: 查找订单 4:显示全部订单 5:修改某项订单 ");
           
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine("输入名称");
                            string A = Console.ReadLine();
                            Console.WriteLine("输入订单号");
                            string B = Console.ReadLine();
                            Console.WriteLine("输入产品名称");
                            string C = Console.ReadLine();
                            Order way = new Order();
                            way.AddWay(A, B, C);
                            Console.WriteLine("输入1继续操作，输入其他结束操作");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("输入订单关键字");
                            string temp = Console.ReadLine();
                            Order way = new Order();
                            way.RemoveWay(temp);
                            Console.WriteLine("输入1进入订单操作，输入其他结束操作");
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("输入订单关键字");
                            string temp = Console.ReadLine();
                            Order way = new Order();
                            way.CheckWay(temp);
                            Console.WriteLine("输入1进入订单操作，输入其他结束操作");
                            break;
                        }
                    case "4":
                        {
                            OrderDetails way = new OrderDetails();
                            way.ShowOrder();
                            Console.WriteLine("输入1进入订单操作，输入其他结束操作");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("输入需要修改的订单某一项数据");
                            string temp1 = Console.ReadLine();
                            Order way = new Order();
                            way.CheckWay(temp1);
                            Console.WriteLine("输入订单修改后的数据");
                            string temp2 = Console.ReadLine();
                            way.ReviseWay(temp1, temp2);
                            Console.WriteLine("输入1进入订单操作，输入其他结束操作");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("请输入正确数字");
                            Console.WriteLine("输入1进入订单操作，输入其他结束操作");
                            break;
                        
                }
            }
        }
    }

    public class OrderDetails : Order
    {
        public void ShowOrder()
        {
            int i = 0;
            while (i < date.Count)
            {
                Console.WriteLine("Name:" + date[i].name + "  Num:" + date[i].num + "  Product:" + date[i].product);
                i++;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            OrderService person1 = new OrderService("hjy", "1", "phone");
            OrderService person2 = new OrderService("yxl", "2", "ipad");
            Order person3 = new Order();
            person3.ListAddWay(person1);
            person3.ListAddWay(person2);
            menu text = new menu();
            Console.WriteLine("输入1进入订单操作，输入其他结束操作");
            int i = 0;
            while (i != 1)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            text.ShowMenu();
                            break;
                        }
                    default:
                        {
                            i = 1;
                            break;
                        }
                }
            }
        }
    }
}
