using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regexpract
{
    class Program
    {
        static void Main(string[] args)
        {
            string input0 = @"宽带接入技术实验室YF314";
            string input = input0.Replace("/","");
            string room = "";
            if (input.Length > 12)
            {
                //string pattern = @"^\w*|\w*$";
                Regex reg = new Regex("^[a-z0-9]*|[a-z0-9]*$", RegexOptions.IgnoreCase);
                MatchCollection mc = reg.Matches(input);
                foreach (Match item in mc)
                {
                    if(item.Value !="")
                    Console.WriteLine(item.Value);
                }
            }
            // return room + input;
        }
    }
}
