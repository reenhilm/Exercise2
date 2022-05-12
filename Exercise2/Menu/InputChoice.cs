using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Menu
{
    internal class InputChoice
    {
        public InputChoice(string selectedinput)
        {
            if (int.TryParse(selectedinput, out int iSelectedInput))
            {
                List<int> validSelections = new List<int>();
                foreach (int i in Enum.GetValues(typeof(InputEnum)))
                    validSelections.Add(i);

                if (validSelections.IndexOf(iSelectedInput) != -1)
                    Input = (InputEnum)Enum.Parse(typeof(InputEnum), iSelectedInput.ToString());
                else
                    Input = InputEnum.Invalid;
            }
            else
                Input = InputEnum.Invalid;
        }


        public InputEnum Input { get; private set; }
        public string Description {
            get
            {
                return GetDescriptionForInput(Input);
            }
        }

        public static string GetDescriptionForInput(InputEnum input)
        {
            //TODO unit test input enum as description?
            switch (input)
            {
                case InputEnum.Lookup1:
                    return Lookup1Description;
                case InputEnum.Multiply10:
                    return Multiply10Description;
                case InputEnum.GetThird:
                    return GetThirdDescription;
                case InputEnum.LookupLots:
                    return LookupLotsDescription;
                case InputEnum.Exit:
                    return ExitDescription;
                case InputEnum.Invalid:
                    return InvalidDescription;

                default:
                    return InvalidDescription;
            }
        }

        private static string Lookup1Description = string.Concat((int)InputEnum.Lookup1, Language.Lookup1English);
        private static string LookupLotsDescription = string.Concat((int)InputEnum.LookupLots, Language.LookupLotsEnglish);
        private static string ExitDescription = string.Concat((int)InputEnum.Exit, Language.ExitEnglish);
        private static string InvalidDescription = Language.InvalidEnglish;
        private static string Multiply10Description = string.Concat((int)InputEnum.Multiply10, Language.Multiply10English);
        private static string GetThirdDescription = string.Concat((int)InputEnum.GetThird, Language.GetThirdEnglish);
    }
}
