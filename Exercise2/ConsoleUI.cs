using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class ConsoleUI : IUI
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

    public class MockUI : IUI
    {
        public static string SetInput { get; set; } = "1";
        public static string lastOutput { get; set; } = "1";
        public string GetInput()
        {
            return SetInput;
        }

        public string GetLastOutput()
        {
            return lastOutput;
        }

        public void SetNextInput(string line)
        {
            SetInput = line;
        }

        public void Print(string? message)
        {
            lastOutput = message;
        }
    }
}
