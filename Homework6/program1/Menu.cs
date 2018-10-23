using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Menu : OrderService
    {
        public Menu()
        {
                bool A = false;
                while (true != A)
                {
                    Console.WriteLine("输入1：添加订单 2：删除订单 3:查找订单 4：输出订单 5:进入订单 6:查询订单价格区间 7:将输入的订单保存 8:载入订单 0：结束");
                    int B = Convert.ToInt32(Console.ReadLine());
                    switch (B)
                    {
                        case 1:
                            {
                            Console.WriteLine("请输入订单名称");
                            var name = Console.ReadLine();
                            Console.WriteLine("请输入订单编号");
                            var clent = Console.ReadLine();
                            Addway(name, clent);
                            Console.WriteLine("进入订单!");
                            IEnumerable<Order> intoTemp = IntoOrder(name);
                            bool AddTemp = true;
                            while (AddTemp)
                            {
                                Console.WriteLine("输入1.添加订单条目 0.返回菜单");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("请输入产品数量");
                                            string num = Console.ReadLine();
                                            Console.WriteLine("请输入产品名称");
                                            string product = Console.ReadLine();
                                            Console.WriteLine("请输入产品单价");
                                            double price = Convert.ToDouble(Console.ReadLine());
                                            IntoOrderAdd(num, product, price, intoTemp);
                                            break;
                                        }
                                    case "0":
                                        {
                                            AddTemp = false;
                                            break;
                                        }
                                }
                            }
                            break;
                            }
                        case 2:
                            {
                                Console.WriteLine("输入想要删除的订单编号或名称");
                                string DeleteTemp = Console.ReadLine();
                                Deleteway(DeleteTemp);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("请输入要查找的订单");
                                string temp = Console.ReadLine();
                                Searchway(temp);
                                break;
                            }
                        case 4:
                            {
                                Showway();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("请输入要进入的订单号或订单名称");
                                string tempIntoOrder = Console.ReadLine();
                                IEnumerable<Order> TEMP = IntoOrder(tempIntoOrder);
                            bool IntoTemp = true;
                            while (IntoTemp)
                            {
                                Console.WriteLine("输入1.添加订单条目 2.删除订单条目 3.筛选订单条目 0.返回菜单");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("请输入产品数量");
                                            string num = Console.ReadLine();
                                            Console.WriteLine("请输入产品名称");
                                            string product = Console.ReadLine();
                                            Console.WriteLine("请输入产品单价");
                                            double price = Convert.ToDouble(Console.ReadLine());
                                            IntoOrderAdd(num, product, price, TEMP);
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("请输入要删除的条目产品名称");
                                            string product = Console.ReadLine();
                                            IntoOrderDelete(product, TEMP);
                                            break;
                                        }
                                    case "3":
                                        {
                                            Console.WriteLine("请分别输入最小价格和最大价格");
                                            double minP = Convert.ToDouble(Console.ReadLine());
                                            double maxP = Convert.ToDouble(Console.ReadLine());
                                            IntoOrderSearch(minP, maxP, TEMP);
                                            break;
                                        }
                                    case "0":
                                        {
                                            IntoTemp = false;
                                            break;
                                        }
                                }
                            }
                                break;
                            }
                        case 6:
                            {
                            Console.WriteLine("输入要查找的价格区间");
                            double Temp1 = Convert.ToDouble(Console.ReadLine());
                            double Temp2 = Convert.ToDouble(Console.ReadLine());
                            SearchAllOrder(Temp1,Temp2);
                                break;
                            }
                        case 7:
                            {
                                Export();
                                break;
                            }
                        case 8:
                            {
                                Import();
                                break;
                            }
                        case 0:
                            {
                                A = true;
                                break;
                            }
                    }
                }
        }
    }
}
