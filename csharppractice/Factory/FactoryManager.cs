using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class FactoryManager
    {
        public static IProduct GetProduct(RoomParts part)
        {
            IFactory factory = null;
            switch (part)
            {
                case RoomParts.Roof:
                    factory = new RoofFactory();
                    break;
                case RoomParts.Window:
                    factory = new WindowFactory();
                    break;
                case RoomParts.Pillar:
                    factory = new PillarFactory();
                    break;
                default:
                    return null;

            }
            IProduct product = factory.Produce();
            Console.WriteLine("生产了一个产品:{0}", product.GetName());
            return product;
        }
    }
}
