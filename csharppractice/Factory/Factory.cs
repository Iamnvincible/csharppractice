using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Factory
    {
    }
    public class RoofFactory : IFactory
    {
        public IProduct Produce()
        {
            return new Roof();
        }
    }
    public class WindowFactory : IFactory
    {
        public IProduct Produce()
        {
            return new Window();
        }
    }
    public class PillarFactory : IFactory
    {
        public IProduct Produce()
        {
            return new Pillar();
        }
    }


}
