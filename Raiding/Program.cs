using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Heros;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<BaseHero> allheros = new List<BaseHero>();

            BaseHero hero;

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();

                    if (type=="Druid")
                    {
                        hero = new Druid(name);
                    }
                    else if (type=="Paladin")
                    {
                        hero = new Paladin(name);
                    }
                    else if (type=="Rogue")
                    {
                        hero = new Rogue(name);
                    }
                    else if (type=="Warrior")
                    {
                        hero = new Warrior(name);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }

                    allheros.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            long bosshealth = long.Parse(Console.ReadLine());

            foreach (var heroes in allheros)
            {
                Console.WriteLine(heroes.CastAbility());
            }


            long allpower = allheros.Select(x => x.Power).Sum();

            if (allpower > bosshealth)
            {
                Console.WriteLine("Victory!");
            }
            else if (bosshealth > allpower)
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
