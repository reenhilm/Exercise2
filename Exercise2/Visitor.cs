using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class Visitor
    {
        public int Age { get; private set; }

        public IPrice Price { get; private set; }

        public Visitor(int age)
        {
            this.Age = age;

            //Create Price According to Age of visitor
            //TODO unit tests with different ages
            if (age < Pricing.exceptionPriceBelow || age >= Pricing.exceptionPriceMin)
                this.Price = new ExceptionPrice();
            else if (age < Pricing.youthPriceBelow)
                this.Price = new YouthPrice();
            else if (age >= Pricing.seniorCitizenMin)
                this.Price = new SeniorCitizenPrice();
            else
                this.Price = new DefaultPrice();
        }
    }
}