using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字");
            string n = "";
            n = Console.ReadLine();
            int s = Int32.Parse(n);
            int i = 2;
            int temp = 0;
            try
            {
                if (s == 1)
                {
                    Console.WriteLine("没有素数因子");
                }
                else
                {
                    Console.Write("素数因子为:");
                    while (i <= s)
                    {
                        if (s % i == 0)
                        {
                            if (temp != i)
                            {
                                temp = i;
                                //Console.Write(temp + " ");//因子不重复
                            }
                            s = s / i;
                            Console.Write(i + " ");//因子重复
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("请输入有效数字");
            }
        }
    }
}
