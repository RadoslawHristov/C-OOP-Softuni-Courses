using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const string ExeptionMessage = "Invalid type of dough.";
        private const string WeightExpMessage = "Dough weight should be in the range [1..200].";

        private Dictionary<string, double> flourTypeAndWeight = new Dictionary<string, double>()
        {
            {"white",1.5},
            {"wholegrain",1}
        };

        private Dictionary<string, double> BakingTechnic = new Dictionary<string, double>()
        {
            {"crispy",0.9},
            {"chewy",1.1},
            {"homemade",1}
        };

        private string flourtype;
        private string bakingtechnique;
        private double weight;

        public Dough(string flourtype, string bakingtechnique, double weight)
        {
            this.FlourType = flourtype;
            this.BakingTechnique = bakingtechnique;
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
                if (value < 1 && value > 200)
                {
                    throw new ArgumentException(WeightExpMessage);
                }
                weight = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return bakingtechnique;
            }
            private set
            {
                if (!BakingTechnic.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExeptionMessage);
                }
                bakingtechnique = value;
            }
        }

        public string FlourType
        {
            get
            {
                return flourtype;
            }
            private set
            {
                if (!flourTypeAndWeight.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExeptionMessage);
                }
                flourtype = value;
            }
        }

        public double Calories
            => 2 * Weight * flourTypeAndWeight[this.FlourType.ToLower()]
            * this.BakingTechnic[this.BakingTechnique.ToLower()];

    }
}
