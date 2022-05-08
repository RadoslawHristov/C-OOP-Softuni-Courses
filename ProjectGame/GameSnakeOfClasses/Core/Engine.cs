using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using SimpleSnake;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace ProjectGameOfMatrix
{
    public class Engine
    {
        private Direction enumDirection;
        private Wall wall;
        private Snake snacks;
        private Dictionary<Direction, Point> pointsDirection;
        private double speed = 350;
        public Engine(Wall wal, Snake snake)
        {
            wall = wal;
            snacks = snake;
            enumDirection = Direction.Right;
            this.pointsDirection = new Dictionary<Direction, Point>
            {
                { Direction.Left ,new Point(-1,0)},
                { Direction.Right ,new Point(1,0)},
                { Direction.Up ,new Point(0,-1)},
                { Direction.Down ,new Point(0,1)}
            };
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInfo = Console.ReadKey();

            if (userInfo.Key == ConsoleKey.LeftArrow)
            {
                if (enumDirection != Direction.Right)
                {
                    enumDirection = Direction.Left;
                }
            }
            else if (userInfo.Key == ConsoleKey.RightArrow)
            {
                if (enumDirection != Direction.Left)
                {
                    enumDirection = Direction.Right;
                }
            }
            else if (userInfo.Key == ConsoleKey.UpArrow)
            {
                if (enumDirection != Direction.Down)
                {
                    enumDirection = Direction.Up;
                }
            }
            else if (userInfo.Key == ConsoleKey.DownArrow)
            {
                if (enumDirection != Direction.Up)
                {
                    enumDirection = Direction.Down;
                }
            }

        }

        private double level = 1;

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool tryMove = snacks.isMoving(this.pointsDirection[this.enumDirection]);
                if (!tryMove)
                {
                    AskPlayerToRestart();
                }

                if (snacks.PointForUpLevel())
                {
                    level++;
                    int leftX = this.wall.LeftX + 5;
                    int topY = 5;
                    Console.SetCursorPosition(leftX, topY);
                    Console.WriteLine($"Level: {level}");
                }

                speed -= 0.2;
                InformationForGame();
                Thread.Sleep((int)speed);
            }
        }

        private void InformationForGame()
        {

            int leftX = this.wall.LeftX + 5;
            int topY = 20;

            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine($"Foot Points:");
            Console.SetCursorPosition(leftX,topY+1);
            Console.WriteLine($"Foot Asterisk-{'*'}- {100} point");
            Console.SetCursorPosition(leftX, topY + 2);
            Console.WriteLine($"Foot Dollar-{'$'}- {200} points");
            Console.SetCursorPosition(leftX, topY + 3);
            Console.WriteLine($"Foot Hash-{'#'}- {300} points");
        }

        private void AskPlayerToRestart()
        {
            int leftX = this.wall.LeftX + 5;
            int topY = 7;

            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine("Would you like continue? y/n");

            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                ExitGame();
            }
        }
        private void ExitGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("GAME OVER");
            Environment.Exit(0);
        }
    }
}
