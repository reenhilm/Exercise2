using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly:InternalsVisibleTo("MainMethods.Tests")]
namespace Exercise2
{

    internal static class Util
    {
        public static string AskFor3Words(string question, string questionName, IUI ui)
        {
            bool success = false;
            string line;
            do
            {
                ui.Print(question);
                line = ui.GetInput();

                //Regex replaces multiple white-spaces with a single one
                if (string.IsNullOrWhiteSpace(line))
                    ui.Print(string.Concat(Language.MustEnterValidEnglish + questionName));
                else if(DuplicateSpacesIntoSingleSpaces(line).Split(" ").Length < 3)
                    ui.Print(string.Concat(Language.MustEnterValidEnglish + questionName));
                else
                    success = true;
            }
            while (!success);
            return line;
        }

        public static string DuplicateSpacesIntoSingleSpaces(string line)
        {
            return Regex.Replace(line, @"\s+", " ").Trim();
        }
        public static string AskForString(string question, string questionName, IUI ui)
        {
            bool success = false;
            string line;
            do
            {
                ui.Print(question);
                line = ui.GetInput();

                if (string.IsNullOrWhiteSpace(line))
                    ui.Print(string.Concat(Language.MustEnterValidEnglish + questionName));
                else
                    success = true;
            }
            while (!success);
            return line;
        }

        public static int AskForInt(string question, string questionName, IUI ui)
        {
            bool success = false;
            int iNumber = -1;
            do
            {
                ui.Print(question);
                string line = ui.GetInput();

                if (!string.IsNullOrWhiteSpace(line))
                { 
                    if(int.TryParse(line, out iNumber))
                        success = true;
                }
                if(!success)
                    ui.Print(string.Concat(Language.MustEnterValidEnglish + questionName));

            }
            while (!success);
            return iNumber;
        }
    }
}
