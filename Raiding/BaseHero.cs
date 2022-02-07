using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        private int power;
        private string name;

        protected BaseHero( string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public virtual int Power
        {
            get { return power; }
            private set { power = value; }
        }

        public virtual string CastAbility()
        {
            return null;
        }

    }
}
