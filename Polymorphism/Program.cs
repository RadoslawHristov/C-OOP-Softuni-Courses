using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal cat = new Cat("Roshko","Wisckas");
            Animal dog = new Dog("Buki","Purina");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
