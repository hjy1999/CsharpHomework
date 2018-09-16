using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入第一个数字");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入第二个数字");
            int B = int.Parse(Console.ReadLine());
            Console.WriteLine("A*B=" + A * B);
            Console.ReadKey();
        }
    }
}
