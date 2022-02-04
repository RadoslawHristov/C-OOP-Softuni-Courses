using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];

                string[] dough = Console.ReadLine().Split();
                string doughName = dough[1];
                string baking = dough[2];
                double weight = double.Parse(dough[3]);

                Dough dought = new Dough(doughName,baking,weight);
                Pizza pizza = new Pizza(pizzaName,dought);

                string toppingtype = Console.ReadLine();

                while (toppingtype  != "END")
                {
                    string[] splited = toppingtype.Split();
                    string type = splited[1];
                    double weights = double.Parse(splited[2]);

                    Topping toppings = new Topping(type, weights);
                    pizza.AddTopping(toppings);

                    toppingtype = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalcolateAllCalories():f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
