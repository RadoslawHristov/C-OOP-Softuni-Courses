using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public int Rating
            => CalculateRating();
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public void Add(Player player)
        {
            players.Add(player);
        }

        public void Remove(string player)
        {
            if (!players.Any(x => x.Name == player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }

            var res = players.FirstOrDefault(x => x.Name == player);
            players.Remove(res);
        }

        private int CalculateRating()
        {
            if (players.Any())
            {
                return (int)Math.Round(this.players.Average(x => x.Statistic));
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"{this.name} - {this.Rating}";
        }
    }
}
