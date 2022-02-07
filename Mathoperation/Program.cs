using System;

namespace Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MathOperations math = new MathOperations();

            Console.WriteLine(math.Add(1, 5));
            Console.WriteLine(math.Add(1.2m,3.4m,4.9m));
            Console.WriteLine(math.Add(1.4,3.1,4.1));
        }
    }
}
