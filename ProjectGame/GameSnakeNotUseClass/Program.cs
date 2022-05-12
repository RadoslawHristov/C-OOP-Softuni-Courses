using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MyProject__snake_game_
{
    class Program
    {
        struct Position
        {
            public int row;
            public int col;

            public Position(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }
        static void Main(string[] args)
        {
            Position[] positions = new Position[]
            {
                new Position(0, 1), //Right
                new Position(0, -1), // Left
                new Position(1, 0), //Down
                new Position(-1, 0) // Up
            };
            int direction = 0;
            Random randomgenerator = new Random();

            Position food = new Position(randomgenerator.Next(0, Console.BufferHeight),
                randomgenerator.Next(0, Console.BufferWidth));

            Console.BufferHeight = Console.BufferWidth;
            Queue<Position> snakeElement = new Queue<Position>();
            int sleeptime = 100;

            for (int i = 1; i <= 5; i++)
            {
                snakeElement.Enqueue(new Position(0, i));
            }


            foreach (Position position in snakeElement)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.Write("*");
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userkey = Console.ReadKey();
                    if (userkey.Key == ConsoleKey.LeftArrow)
                    {
                        direction = 1;
                    }
                    if (userkey.Key == ConsoleKey.RightArrow)
                    {
                        direction = 0;
                    }
                    if (userkey.Key == ConsoleKey.DownArrow)
                    {
                        direction = 2;
                    }
                    if (userkey.Key == ConsoleKey.UpArrow)
                    {
                        direction = 3;
                    }
                }

                Position head = snakeElement.Last();
                Position nextdirection = positions[direction];
                Position snakenewHeaad = new Position(head.row + nextdirection.row,
                         head.col + nextdirection.col);

                if (snakenewHeaad.row < 0 || snakenewHeaad.col < 0
                || snakenewHeaad.row >= Console.BufferHeight
                || snakenewHeaad.col >= Console.BufferWidth
                || snakeElement.Contains(snakenewHeaad))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game Over");
                    Console.WriteLine($"You points are: {(snakeElement.Count-5)* 100}");
                    return;
                }
                snakeElement.Enqueue(snakenewHeaad);
                Console.SetCursorPosition(snakenewHeaad.col, snakenewHeaad.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*");
                if (snakenewHeaad.col == food.col && snakenewHeaad.row == food.row)
                {

                    do
                    {
                        food = new Position(randomgenerator.Next(0, Console.BufferHeight),
                       randomgenerator.Next(0, Console.BufferWidth));
                    }
                    while (snakeElement.Contains(food));
                    Console.SetCursorPosition(food.col, food.row);
                    Console.WriteLine("@");
                    Thread.Sleep(sleeptime);
                }
                else
                {
                    Position last = snakeElement.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.WriteLine(" ");
                }

                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("@");
                Thread.Sleep(sleeptime);

            }
        }
    }
}
