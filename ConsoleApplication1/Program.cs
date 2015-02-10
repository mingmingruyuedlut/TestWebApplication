using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToUniversalTime());
            Console.WriteLine(DateTime.Now.ToLocalTime());
            Console.WriteLine(DateTime.Now.ToOADate());
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine(DateTime.Now.ToFileTimeUtc());
            Console.ReadLine();
        }
    }
}
