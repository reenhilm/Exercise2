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
                List<int> validSelections = new ();
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
            return input switch
            {
                InputEnum.Lookup1 => Lookup1Description,
                InputEnum.Multiply10 => Multiply10Description,
                InputEnum.GetThird => GetThirdDescription,
                InputEnum.LookupLots => LookupLotsDescription,
                InputEnum.Exit => ExitDescription,
                InputEnum.Invalid => InvalidDescription,
                _ => InvalidDescription,
            };
        }

        private readonly static string Lookup1Description = string.Concat((int)InputEnum.Lookup1, Language.Lookup1English);
        private readonly static string LookupLotsDescription = string.Concat((int)InputEnum.LookupLots, Language.LookupLotsEnglish);
        private readonly static string ExitDescription = string.Concat((int)InputEnum.Exit, Language.ExitEnglish);
        private readonly static string InvalidDescription = Language.InvalidEnglish;
        private readonly static string Multiply10Description = string.Concat((int)InputEnum.Multiply10, Language.Multiply10English);
        private readonly static string GetThirdDescription = string.Concat((int)InputEnum.GetThird, Language.GetThirdEnglish);
    }
}
