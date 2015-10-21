using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @operator
{
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point { X = 2.3, Y = 5.9 };
            Point b = new Point { X = 9.4, Y = 2.4 };
            Point c = a + b;
            Console.WriteLine(c.X + "" + c.Y);
            Console.ReadLine();
        }
    }
}
