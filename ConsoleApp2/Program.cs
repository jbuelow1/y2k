using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte t = 127;

            ++t;
            Console.WriteLine(t);
            System.Threading.Thread.Sleep(5000);
        }
    }
}
