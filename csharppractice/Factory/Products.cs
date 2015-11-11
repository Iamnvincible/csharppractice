using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Products
    {
    }
    public class Roof : IProduct
    {
        public string GetName()
        {
            return "屋顶";
        }
        
    }
    public class Window : IProduct
    {
        public string GetName()
        {
            return "窗户";
        }
    }
    public class Pillar : IProduct
    {
        public string GetName()
        {
            return "柱子";
        }
    }
}
