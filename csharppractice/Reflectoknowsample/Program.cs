using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflectoknowsample
{
    class Program
    {
        private String _MyString;
        public Program(String mystring)
        {
            _MyString = mystring;
        }

        public override string ToString()
        {
            return _MyString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("简单程序集");
            Console.Read();
        }
    }
}
