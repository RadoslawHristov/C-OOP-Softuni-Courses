using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private char foodsymbol;
        private Random random;
        private int foodPoints;
        private readonly Queue<Point> SnakeElement;

        protected Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.FoodPoints = points;
            this.foodsymbol = foodSymbol;
            this.random = new Random();
            SnakeElement = new Queue<Point>();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElement)
        {
            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElement.Any(x => x.LeftX == this.LeftX &&
                                                          x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElement.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            if (this.FoodPoints==3)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                this.Draw(foodsymbol);
            }
            else if (FoodPoints==2)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                this.Draw(foodsymbol);
            }
            else if (FoodPoints==1)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                this.Draw(foodsymbol);
            }
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool isFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
