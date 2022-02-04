using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dought = dough;
            toppings = new List<Topping>();
        }

        public Dough Dought
        {
            get { return dough; }
            set { dough = value; }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Topping> Toppings
            => this.toppings;
        public double CalcolateAllCalories()
        {
            double result = this.dough.Calories + toppings.Sum(x => x.Calories);
            return result;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }
    }
}
