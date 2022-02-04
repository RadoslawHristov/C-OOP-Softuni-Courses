using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> ToptypeAndweight = new Dictionary<string, double>()
        {
            {"meat",1.2},
            {"veggies",0.8},
            {"cheese",1.1},
            {"sauce",0.9}
        };

        private string toppingtype;
        private double weight;
        public Topping(string toppingtype, double weight)
        {
            this.ToppingType = toppingtype;
            this.Weight = weight;
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingtype} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
       
        public string ToppingType
        {
            get
            {
                return toppingtype;
            }
            private set
            {
                if (!ToptypeAndweight.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingtype = value;
            }
        }

        public double Calories
            => 2 * Weight * ToptypeAndweight[this.ToppingType.ToLower()];
    }
}
