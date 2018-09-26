using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public abstract class FatherShape
    {
        private string myID;
        public FatherShape(string i)
        {
            id = i;
        }
        public string id   //获得图形
        {
            get { return myID; }
            set { myID = value; }
        }
        public abstract double Area { get; }
        public string info
        {
            get
            {
                return id +"面积:"+ Area;
            }
        }
    }

    public class Square : FatherShape
    {
        private int myside;
        public Square(int side, string ID) : base(ID)
        {
            myside = side;
        }
        public override double Area
        {
            get { return myside * myside; }
        }
        
    }

    public class Circle : FatherShape
    {
        private int myradius;
        public Circle(int radius, string ID) : base(ID)
        {
            myradius = radius;
        }
        public override double Area
        {
            get { return myradius * myradius * System.Math.PI; }
        }
       
    }

    public class Rectangle : FatherShape
    {
        private int mywidth, myheight;
        public Rectangle(int width, int height, string ID) : base(ID)
        {
            myheight = height;mywidth = width;
        }
        public override double Area
        {
            get { return mywidth * myheight; }
        }
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            FatherShape[] getID =
            {
            new Square(10,"正方形"),
            new Circle(5, "圆形"),
            new Rectangle(10, 5, "长方形")
            };
            Console.WriteLine("输出:");
            foreach (FatherShape s in getID)
            {
                Console.WriteLine(s.info);
            }
        }
    }
}
