using Exercise2.Menu;
using System;
using System.Text.RegularExpressions;

namespace Exercise2
{
    internal class Program
    {
        static ConsoleUI ui = new ConsoleUI();
        static void Main(string[] args)
        {
            InputChoice inputChoice;
            do
            {
                PrintMenu();
                inputChoice = new InputChoice(ui.GetInput());

                ui.Print(inputChoice.Description);
                switch (inputChoice.Input)
                {
                    case InputEnum.Lookup1:
                        Lookup1Visitor();
                        break;
                    case InputEnum.Multiply10:
                        Multiply10();
                        break;
                    case InputEnum.GetThird:
                        GetThird();
                        break;
                    case InputEnum.LookupLots:
                        LookupLots();
                        break;
                }
            }
            while (inputChoice.Input != InputEnum.Exit);
            ui.Print(Language.ExitingEnglish);
            Environment.Exit(0);
        }

        private static void PrintMenu()
        {
            ui.Print(Language.ChooseEnglish);
            //TODO unit test menu is visible
            ui.Print(InputChoice.GetDescriptionForInput(InputEnum.Lookup1));
            ui.Print(InputChoice.GetDescriptionForInput(InputEnum.Multiply10));
            ui.Print(InputChoice.GetDescriptionForInput(InputEnum.GetThird));
            ui.Print(InputChoice.GetDescriptionForInput(InputEnum.LookupLots));
            ui.Print(InputChoice.GetDescriptionForInput(InputEnum.Exit));
        }

        public static void GetThird()
        {
            //Output third word of input line
            string line = Util.AskFor3Words(Language.EnterAtLeast3WordsEnglish, Language.Line3WordsEnglish, ui);
            //Regex replaces multiple white-spaces with a single one
            ui.Print(Regex.Replace(line, @"\s+", " ").Trim().Split(" ")[2]);
        }

        public static void Multiply10()
        {
            //Multiply input word 10 times and output those in a single line
            string word = Util.AskForString(Language.EnterWordForRepeatEnglish, Language.WordEnglish, ui);
            string output = word;
            for(int i = 0; i < 9; i++)
                output += string.Concat(" ", word);

            ui.Print(output);
        }

        public static void Lookup1Visitor()
        {
            int age = Util.AskForInt(Language.EnterAgeEnglish, Language.AgeEnglish, ui);
            Visitor v = new Visitor(age);

            //The ExceptionalPrice should not be printed and does not have a Name property
            if (v.Price.GetType() != typeof(ExceptionPrice))
                ui.Print(v.Price.ToString());
        }

        public static void LookupLots()
        {
            int iAmountVisitors = Util.AskForInt(Language.EnterAmountVisitorsEnglish, Language.AmountVisitorsEnglish, ui);

            //Calculate total price for selected amount of visitors
            double dTotal = 0;
            for (int i=0; i< iAmountVisitors; i++)
            {
                int age = Util.AskForInt(Language.EnterAgeEnglish, Language.AgeEnglish, ui);
                Visitor v = new Visitor(age);
                dTotal += v.Price.Value;
            }

            ui.Print(string.Concat(Language.PrintAmountVisitorsEnglish, iAmountVisitors));
            ui.Print(string.Concat(Language.PrintTotalPriceLotsEnglish, dTotal, Pricing.currency));
        }
    }
}