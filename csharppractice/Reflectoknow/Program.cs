using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflectoknow
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"..\..\..\Reflectoknowsample\bin\Debug\Reflectoknowsample.exe");
            AnalyseHelper.AnalyzeAssembly(assembly);

            // 创建一个程序集中的类型的对象
            Console.WriteLine("利用反射创建对象");
            string[] paras = { "测试一下反射效果" };
            object obj = assembly.CreateInstance(assembly.GetModules()[0].GetTypes()[0].ToString(), true, BindingFlags.CreateInstance, null, paras, null, null);
            Console.WriteLine(obj.ToString()+"-----");

            Console.ReadKey();
        }
    }
}
