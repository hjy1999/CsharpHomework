using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace program1
{
    public class OrderService
    {
        public static List<Order> data = new List<Order>();

        public Order Addway(string name,string clent)
        {
            Order person = new Order(name, clent);
            data.Add(person);
            return person;
        }

        public bool Deleteway(string temp)
        {
            var search = data.Where(a => a.Name == temp || a.Clent == temp);
            if (search.Count() == 0) { Console.WriteLine("没有找到要删除的数据"); return false; }
            else
            {
                foreach (Order n in search.ToList())
                {
                    data.Remove(n);
                }
                return true;
            }
        }

        public void Searchway(string temp)
        {
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

        public IEnumerable<Order> IntoOrder(string A)
        {
            var Search = data.Where(a => a.Clent == A || a.Name == A);
            if (Search.Count() == 0)
            {
                Console.WriteLine("没有找到订单数据");
                return Search;
            }
            else
            {
                return Search;
            }
        }

        public void IntoOrderAdd(string num,string product,double price,IEnumerable<Order>search)
        {
            OrderDetails temp = new OrderDetails(num, product, price);
            foreach (Order n in search)
            {
                n.Items.Add(temp);
            }
        }

        public void IntoOrderDelete(string product, IEnumerable<Order>search)
        {
            foreach (Order n in search)
            {
                foreach (OrderDetails m in n.Items)
                {
                    n.Items.Remove(m);
                    break;
                }
            }
        }

        public void IntoOrderSearch(double minprice,double maxprice,IEnumerable<Order>search)
        { 
            foreach (Order n in search)
            {
                Console.WriteLine("Name : " + n.Name + " Clent : " + n.Clent);
                var Temp = n.Items.Where(a => a.Price >= Convert.ToDouble(minprice) && a.Price <= Convert.ToDouble(maxprice));
                foreach (OrderDetails m in Temp)
                {
                    Console.WriteLine("    Product:" + m.Product + "  Num:" + m.Num + "  Price:" + m.Price);
                }
            } 
        }

        public void SearchAllOrder(double Temp1,double Temp2)
        {
            try
            {
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
                Console.WriteLine("输入要保存的路径");
                string xmlFileAdress = Console.ReadLine();
                if (!Directory.Exists(xmlFileAdress)) { throw new Exception("没有找到地址"); }
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
            catch (FileNotFoundException)
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
                if (!Directory.Exists(FileAdrssion)) { throw new Exception("没有找到文件"); }
                Console.WriteLine("请输入.xml文件名称");
                string FileName = Console.ReadLine();
                StringBuilder FileAdreeName = new StringBuilder();
                FileAdreeName.Append(FileAdrssion);
                FileAdreeName.Append("\\");
                FileAdreeName.Append(FileName);
                if (!File.Exists(FileAdreeName.ToString())) { throw new MyException("没有找到文件"); }

                //方法 2.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                FileStream fileStream = new FileStream(FileAdreeName.ToString(), FileMode.Open, FileAccess.Read);
                data = xmlSerializer.Deserialize(fileStream) as List<Order>;
                fileStream.Close();

                //之前的傻逼方法 1.
                //XmlDocument XmlAddress = new XmlDocument();
                //XmlAddress.Load(FileAdreeName.ToString());
                //XmlNodeList order = XmlAddress.SelectNodes("//ArrayOfOrder//Order");//获取所有Order节点 ,保存在一个list里面              
                //foreach (XmlNode n in order)
                //{
                //    string Name = ((XmlElement)n).GetElementsByTagName("Name")[0].InnerText;
                //    string Clent = ((XmlElement)n).GetElementsByTagName("Clent")[0].InnerText;
                //    Order person = new Order(Name, Clent);
                //    XmlNode orderdetails = n.SelectSingleNode("Items"); //获取order里的orderDetails
                //    XmlNodeList orderDetails = orderdetails.ChildNodes;  //把orderDetails 变成list
                //    int j = 0;
                //    foreach (XmlNode m in orderDetails)
                //    {
                //        string Num = ((XmlElement)m).GetElementsByTagName("Num")[j].InnerText;
                //        string Product = ((XmlElement)m).GetElementsByTagName("Product")[j].InnerText;
                //        string Price = ((XmlElement)m).GetElementsByTagName("Price")[j].InnerText;
                //        OrderDetails person2 = new OrderDetails(Num, Product, Convert.ToDouble(Price));
                //        person.Items.Add(person2);
                //    }
                //    data.Add(person);
                //}
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("文件夹地址错误");
            }
            catch (MyException)
            {
                Console.WriteLine("没有找到文件,请输入正确的文件地址");
            }
        }
       
    }
}
