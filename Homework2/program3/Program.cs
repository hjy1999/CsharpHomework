using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("获得2-100之间所有素数");
            int num = 100;
            bool[] a = new bool[num];
            for (int i = 0; i < num; i++)
            {
                a[i] = true;
            }
            a[0] = false;
            a[1] = false;
            for (int i = 2; i < num; i++)
            {
                for (int k = 2; k < num; k++)
                {
                    if (k > i && k % i == 0)
                    {
                        a[k] = false;
                    }
                }
            }
            for (int i = 0; i < num; i++)
            {
                if (a[i] == true)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
