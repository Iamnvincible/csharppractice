using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Interfaces
    {
    }
    public enum RoomParts
    {
        Roof,
        Window,
        Pillar
    }
    public interface IFactory
    {
        IProduct Produce();
    }
    public interface IProduct
    {
        string GetName();
    }

}
