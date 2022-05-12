using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{



    internal class YouthPrice : PrintablePrice
    {
        public YouthPrice()
        {
            Value = Pricing.youthPrice;
            Name = Language.youthPriceDescription;
        }
    }

    internal class SeniorCitizenPrice : PrintablePrice
    {
        public SeniorCitizenPrice()
        {
            Value = Pricing.seniorcitizenPrice;
            Name = Language.seniorcitizenPriceDescription;
        }
    }

    internal class DefaultPrice : PrintablePrice
    {
        public DefaultPrice()
        {
            Value = Pricing.defaultPrice;
            Name = Language.defaultPriceDescription;
        }
    }
    internal class PrintablePrice : AllPrices, IPrice
    {
        private string name = null!;
        public string Name {
            get
            {
                    return name;
            }
            set
            {
                    name = value;
            }
        }

        public override string? ToString()
        {
            return string.Concat(Name, " ", Value, "kr");
        }
    }



    internal class ExceptionPrice : AllPrices, IPrice
    {
        public ExceptionPrice()
        {
            Value = Pricing.exceptionPrice;
        }
    }

    internal class AllPrices
    {
        private double dValue;
        public double Value
        {
            get
            {
                return dValue;
            }
            set
            {
                dValue = value;
            }
        }
    }

    public interface IPrice
    {
        public double Value { get; set; }
    }
}
