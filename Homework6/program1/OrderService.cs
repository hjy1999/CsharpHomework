using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace program1
{
    public class OrderService
    {
        public static List<Order> data = new List<Order>();

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
                try
                {
                    Console.WriteLine("输入1继续添加条目，输入0停止添加并返回菜单");
                    string S = Console.ReadLine();
                    if (S != "0" && S != "1") { throw new MyException("输入的数字不对"); }
                    switch (S)
                    {
                        case "1":
                            {
                                try
                                {
                                    Console.WriteLine("请输入商品种类");
                                    String product = Console.ReadLine();
                                    Console.WriteLine("请输入商品数量");
                                    String num = Console.ReadLine();
                                    if (Convert.ToInt32(num) < 1) { throw new MyException("数据异常"); }
                                    Console.WriteLine("请输入商品单价");
                                    String PRICE = Console.ReadLine();
                                    if (Convert.ToDouble(PRICE) < 1) { throw new MyException("数据异常"); }
                                    double price = Convert.ToDouble(PRICE);
                                    OrderDetails person2 = new OrderDetails(num, product, price);
                                    person.Items.Add(person2);

                                }
                                catch (MyException)
                                {
                                    Console.WriteLine("请输入正确的数据");
                                }
                                break;
                            }
                        case "0":
                            {
                                temp = false;
                                break;
                            }
                    }
                }
                catch (MyException)
                {
                    Console.WriteLine("请输入1或0");
                }
            }
            data.Add(person);

        }

        public static void Deleteway()
        {
            Console.WriteLine("输入想要删除的订单编号或名称");
            string temp = Console.ReadLine();
            var search = data.Where(a => a.Name == temp || a.Clent == temp);
            if (search.Count() == 0) Console.WriteLine("没有找到要删除的数据");
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
            if (search.Count() == 0) Console.WriteLine("没有找到数据");
            foreach (Order n in search.ToList())
            {
                Console.WriteLine("订单名:" + n.Name + "订单号" + n.Clent);
                foreach (OrderDetails m in n.Items)
                {
                    Console.WriteLine("       数量:" + m.Num + "产品:" + m.Product + "单价:" + m.Price);
                }
            }
        }

        public void Showway()
        {
            if (data.Count() == 0) Console.WriteLine("订单数据为空");
            else
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
        }

        public void IntoOrder()
        {
            Console.WriteLine("请输入要进入的订单号或订单名称");
            string A = Console.ReadLine();
            var Search = data.Where(a => a.Clent == A || a.Name == A);
            if (Search.Count() == 0) Console.WriteLine("没有找到订单数据");
            else
            {
                Console.WriteLine("进入订单!");
                bool Temp = true;
                while (Temp)
                {
                    Console.WriteLine("输入1：添加订单条目 2：删除订单条目 3：筛选价格 -1：返回菜单");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                try
                                {
                                    Console.WriteLine("请输入商品种类");
                                    String product = Console.ReadLine();
                                    Console.WriteLine("请输入商品数量");
                                    String num = Console.ReadLine();
                                    if (Convert.ToInt32(num) < 1) { throw new MyException("输入的数据不正确"); }
                                    Console.WriteLine("请输入商品单价");
                                    String PRICE = Console.ReadLine();
                                    double price = Convert.ToDouble(PRICE);
                                    if (Convert.ToInt32(PRICE) < 1) { throw new MyException("输入的数据不正确"); }
                                    OrderDetails person2 = new OrderDetails(num, product, price);
                                    foreach (Order n in Search)
                                    {
                                        n.Items.Add(person2);
                                    }
                                }
                                catch (MyException)
                                {
                                    Console.WriteLine("数据异常");
                                }
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("请输入要删除的产品名称");
                                string Temp2 = Console.ReadLine();
                                foreach (Order n in Search)
                                {
                                    var Search2 = n.Items.Where(a => a.Product == Temp2);
                                    foreach (OrderDetails m in Search2)
                                    {
                                        n.Items.Remove(m);
                                        break;
                                    }
                                }
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("输入价钱");
                                string Temp2 = Console.ReadLine();
                                double PRICE = Convert.ToDouble(Temp);
                                foreach (Order n in Search)
                                {
                                    var Check2 = n.Items.Where(a => a.Price <= PRICE);
                                    if (Check2.Count() == 0) { Console.WriteLine("没有这个价格的订单"); }
                                    else
                                    {
                                        Console.WriteLine("姓名：" + n.Name + "订单号：" + n.Clent);
                                        foreach (OrderDetails m in Check2)
                                        {
                                            Console.WriteLine("  产品：" + m.Product + "数量：" + m.Num + "单价：" + m.Price);
                                        }
                                    }
                                }
                                break;
                            }
                        case "-1":
                            {
                                Temp = false;
                                break;
                            }
                    }
                }
            }
        }

        public void SearchAllOrder()
        {
            try
            {
                Console.WriteLine("输入要查找的价格区间");
                double Temp1 = Convert.ToDouble(Console.ReadLine());
                double Temp2 = Convert.ToDouble(Console.ReadLine());
                if (Temp1 < 0 || Temp2 < 0 || Temp1 >= Temp2) { throw new MyException("价格区间不正确"); }
                var quary1 = data.Where(n => n.Items.Where(m => m.Price >= Temp1 && m.Price <= Temp2).Any());
                if (quary1.Count() == 0) Console.WriteLine("订单数据为空");
                else
                {
                    foreach (Order n in quary1)
                    {
                        Console.WriteLine("订单名：" + n.Name + "订单号：" + n.Clent);
                        var quary2 = n.Items.Where(a => a.Price <= Temp2 && a.Price >= Temp1);
                        foreach (OrderDetails m in quary2)
                        {
                            Console.WriteLine("产品名称：" + m.Product + "数量：" + m.Num + "产品单价：" + m.Price);
                        }
                    }
                }
            }
            catch (MyException)
            {
                Console.WriteLine("请输入正确的价格区间");
            }
        }

        public void Export()//序列化
        {
            XmlSerializer toxml = new XmlSerializer(data.GetType());
            try
            {
                Console.WriteLine("初始没有数据");
                Console.WriteLine("输入要保存的路径");
                string xmlFileAdress = Console.ReadLine();
                if (!Directory.Exists(xmlFileAdress)) { throw new MyException("没有找到地址"); }
                Console.WriteLine("请输入要保存的文件名");
                string xmlFileName = Console.ReadLine();
                StringBuilder xmlFileAddressName = new StringBuilder();
                xmlFileAddressName.Append(xmlFileAdress);
                xmlFileAddressName.Append("\\");
                xmlFileAddressName.Append(xmlFileName);
                FileStream fileCreat = new FileStream(xmlFileAddressName.ToString(), FileMode.Create);
                toxml.Serialize(fileCreat, data);
                fileCreat.Close();
            }
            catch (MyException)
            {
                Console.WriteLine("没有找到文件夹");
            }
        }

        public void Import()//反序列化
        {
            try
            {
                Console.WriteLine("请输入.xml文件路径");
                string FileAdrssion = Console.ReadLine();
                if (!Directory.Exists(FileAdrssion)) { throw new MyException("没有找到文件"); }
                Console.WriteLine("请输入.xml文件名称");
                string FileName = Console.ReadLine();
                StringBuilder FileAdreeName = new StringBuilder();
                FileAdreeName.Append(FileAdrssion);
                FileAdreeName.Append("\\");
                FileAdreeName.Append(FileName);
                if (!File.Exists(FileAdreeName.ToString())) { throw new MyException("没有找到文件"); }
                string showxml = File.ReadAllText(FileAdreeName.ToString());
                Console.WriteLine(showxml);
            }
            catch (MyException)
            {
                Console.WriteLine("没有找到文件,请输入正确的文件地址");
            }
        }

        public OrderService()
        {

            bool A = false;
            while (true != A)
            {
                Console.WriteLine("输入1：添加订单 2：删除订单 3:查找订单 4：输出订单 5:进入订单 6:查询订单价格区间 7:将输入的订单保存 8:载入订单 -1：结束");
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
                            IntoOrder();
                            break;
                        }
                    case 6:
                        {
                            SearchAllOrder();
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
