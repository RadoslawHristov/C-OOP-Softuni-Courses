﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopingSpree
{
    public class Product
    {
        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        private string name;
        private double cost;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }
    }
}
