using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflectoknow
{
    public class AnalyseHelper
    {
        public static void AnalyzeAssembly(Assembly assembly)
        {
            Console.WriteLine("程序集名称:" + assembly.FullName);
            Console.WriteLine("程序集位置:" + assembly.Location);
            Console.WriteLine("程序集是否在GAC中:" + assembly.GlobalAssemblyCache.ToString());
            Console.WriteLine("包含程序集的模块名" +
                assembly.ManifestModule.Name);
            Console.WriteLine("运行程序集需要的CLR版本：" +
                assembly.ImageRuntimeVersion);
            Console.WriteLine("现在开始分析程序集中的模块");
            Module[] modules = assembly.GetModules();
            foreach (Module module in modules)
            {
                AnalyzeModule(module);
            }
        }
        /// <summary>
        /// 分析模块
        /// </summary>
        public static void AnalyzeModule(Module module)
        {
            Console.WriteLine("模块名：" + module.Name);
            Console.WriteLine("模块的UUID：" + module.ModuleVersionId);
            Console.WriteLine("开始分析模块下的类型");
            Type[] types = module.GetTypes();
            foreach (Type type in types)
            {
                AnalyzeType(type);
            }
        }

        /// <summary>
        /// 分析类型
        /// </summary>
        public static void AnalyzeType(Type type)
        {
            Console.WriteLine("类型名字：" + type.Name);
            Console.WriteLine("类型的类别是：" + type.Attributes);
            if (type.BaseType != null)
                Console.WriteLine("类型的基类是：" + type.BaseType.Name);
            Console.WriteLine("类型的GUID是：" + type.GUID);
            //设置感兴趣的类型成员
            BindingFlags flags = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            //分析成员
            FieldInfo[] fields = type.GetFields(flags);
            if (fields.Length > 0)
            {
                //Console.WriteLine("开始分析类型的成员");
                foreach (FieldInfo field in fields)
                {
                    // 分析成员
                }
            }
            //分析包含的方法
            MethodInfo[] methods = type.GetMethods(flags);
            if (methods.Length > 0)
            {
                //Console.WriteLine("开始分析类型的方法");
                foreach (MethodInfo method in methods)
                {
                    // 分析方法
                }
            }
            //分析属性
            PropertyInfo[] properties = type.GetProperties(flags);
            if (properties.Length > 0)
            {
                //Console.WriteLine("开始分析类型的属性");
                foreach (PropertyInfo property in properties)
                {
                    // 分析属性
                }
            }
        }
    }
}
