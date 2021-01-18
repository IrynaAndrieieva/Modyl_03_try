using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try
{
    class Program
    {
        static void Main(string[] args)
        {
            var unicodeString = char.ConvertFromUtf32(0x1F642);
            Console.Write(unicodeString);
            Starter.Run();
            Console.ReadLine();
        }      
    }
}
