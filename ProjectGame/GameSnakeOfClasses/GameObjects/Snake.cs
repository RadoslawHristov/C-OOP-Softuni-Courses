using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Wall wall;
        private Queue<Point> snakeElements;
        private Food[] food;
        private int footIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.food = new Food[]
            {
                new FoodHash(this.wall),
                new FoodDollar(this.wall),
                new FoodAsterisk(this.wall)
            };
            this.CreateSnake();
        }
        private const char SnakeSymbol = '\u25CF';

        private void CreateSnake()
        {
            this.snakeElements = new Queue<Point>();
            for (int topY = 1; topY <= 6; topY++)
            {
                Point point = new Point(topY, 1);
                this.snakeElements.Enqueue(point);
                point.Draw(SnakeSymbol);
            }

            this.footIndex = GetRandomIndex();
            this.food[footIndex].SetRandomPosition(this.snakeElements);

        }

        private double countFood;
        private double curentCountFood;

        public bool PointForUpLevel()
        {
            if (curentCountFood >= 10)
            {
                curentCountFood = 0;
                return true;
            }
            return false;
        }

        private void Eat(int nextleftX, int nextTopY)
        {
            Food foods = this.food[footIndex];
            for (int i = 0; i < foods.FoodPoints; i++)
            {
                countFood++;
                curentCountFood++;
                this.snakeElements.Enqueue(new Point(nextleftX, nextTopY));
            }

            this.footIndex = GetRandomIndex();
            this.food[footIndex].SetRandomPosition(this.snakeElements);
            int leftX = this.wall.LeftX + 5;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine($"Points: {countFood* 100}");
        }

        public int GetRandomIndex()
            => new Random().Next(0, this.food.Length);

        public bool isMoving(Point point)
        {
            Point snakeHEAD = this.snakeElements.Last();
            int nextleftX = snakeHEAD.LeftX + point.LeftX;
            int nextTopY = snakeHEAD.TopY + point.TopY;

            bool isSnacke = this.snakeElements.Any(x => x.LeftX == nextleftX && x.TopY == nextTopY);

            if (isSnacke)
            {
                return false;
            }

            bool isWall = nextleftX < 0 || nextTopY < 0 || nextleftX > this.wall.LeftX || nextTopY > this.wall.TopY;

            if (isWall)
            {
                return false;
            }

            bool isFood = this.food[footIndex].LeftX == nextleftX &&
                          this.food[footIndex].TopY == nextTopY;

            if (isFood)
            {
                this.Eat(nextleftX, nextTopY);
            }

            Point curentpoint = new Point(nextleftX, nextTopY);
            this.snakeElements.Enqueue(curentpoint);
            curentpoint.Draw(SnakeSymbol);

            Point lastpoint = snakeElements.Dequeue();
            lastpoint.Draw(' ');
            return true;
            // Oh mayGod snack is move finally!!! 
        }
    }
}