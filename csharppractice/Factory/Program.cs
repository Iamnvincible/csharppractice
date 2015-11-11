using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            IProduct window = FactoryManager.GetProduct(RoomParts.Window);
            Console.WriteLine("我获取到了:{0}", window.GetName());
            Console.ReadKey();
        }
    }
}
