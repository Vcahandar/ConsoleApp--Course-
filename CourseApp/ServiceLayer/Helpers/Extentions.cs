using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers
{
    public static class Extentions
    {
        public static void WriteConsole(this ConsoleColor color,string text)
        {
            Console.ForegroundColor= color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
