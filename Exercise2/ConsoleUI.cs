using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class ConsoleUI
    {
        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public void Print(string? message)
        {
            Console.WriteLine(message);
        }
    }
}
