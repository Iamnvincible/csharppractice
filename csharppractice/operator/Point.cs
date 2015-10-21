using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @operator
{
    public class Point
    {
        private double  x,y;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        public static Point operator +(Point a,Point b)
        {
            Point t = new Point();
            t.X = a.X + b.X;
            t.Y = b.y + a.y;
            return t;
        }
    }
}
