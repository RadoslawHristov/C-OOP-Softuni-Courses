using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] comand = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (comand[0] == "Team")
                    {
                        teams.Add(new Team(comand[1]));
                    }
                    else if (comand[0] == "Add")
                    {
                        if (!teams.Any(x => x.Name == comand[1]))
                        {
                            throw new ArgumentException($"Team {comand[1]} does not exist.");
                        }
                        else
                        {
                            var curentteams = teams.First(x => x.Name == comand[1]);
                            curentteams.Add(new Player(comand[2], int.Parse(comand[3]), int.Parse(comand[4]), int.Parse(comand[5]), int.Parse(comand[6])
                                , int.Parse(comand[7])));
                        }
                    }
                    else if (comand[0] == "Remove")
                    {
                        var removet = teams.First(x => x.Name == comand[1]);
                        removet.Remove(comand[2]);
                    }
                    else if (comand[0] == "Rating")
                    {
                        if (!teams.Any(t => t.Name == comand[1]))
                        {
                            throw new ArgumentException($"Team {comand[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine(teams.First(t => t.Name == comand[1]).ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                   
                }
                input = Console.ReadLine();
            }

        }
    }
}
