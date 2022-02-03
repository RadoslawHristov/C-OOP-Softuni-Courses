using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            Team teams = new Team("radi");
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var peoples = new Person(input[0], input[1], int.Parse(input[2]),decimal.Parse(input[3]));
                teams.AddPlayer(peoples);
            }

            Console.WriteLine($"First team has {teams.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {teams.ReserveTeam.Count} players.");
        }
    }
}
