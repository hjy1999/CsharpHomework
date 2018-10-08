using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    using System;
    public class clockPub
    {
        private string time;
        public delegate void clockDelegate();
        public event clockDelegate clockEventer;
        public void beginEvent()
        {
            while (time != DateTime.Now.ToShortTimeString().ToString())
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString().ToString());
                System.Threading.Thread.Sleep(1000);
                //Console.WriteLine("时间未到,输入回车继续");
                //Console.ReadLine();
            }
            clockEventer();
        }
        public string SetClockTime()
        {
            time = Console.ReadLine();
            return time;
        }
    }

    public class clockSub
    {
        public void warn()
        {
            Console.WriteLine("时间到");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            clockPub Gettime = new clockPub();
            clockSub warntime = new clockSub();
            Gettime.clockEventer += new clockPub.clockDelegate(warntime.warn);
            Console.WriteLine("输入设定的时间(hh:ss)");
            Gettime.SetClockTime();
            Gettime.beginEvent();
            
        }
    }
}
