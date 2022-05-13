using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;

namespace ProjectGameCheesM
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] field = new char[3,3];

            GetField(field);

            char playerOne = 'X';
            char playerTwo = 'O';

            int countPlayer = 1;

            while (true)
            {
                int[] position = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();
                int row = position[0];
                int col = position[1];
                //Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                if (GetValidIndexOfField(field, row, col))
                {
                    if (countPlayer % 2 != 0)
                    {
                        Console.WriteLine("Player One to move");
                        field[row,col] = playerOne;
                        countPlayer++;
                        PrintMatrixField(field);
                        if (GetPlayerOneWin(field))
                        {
                            Console.WriteLine("Player One Win");
                            break;
                        }
                    }
                    else if (countPlayer % 2 == 0)
                    {
                        Console.WriteLine("Player Two to move");
                        field[row,col] = playerTwo;
                        countPlayer++;
                        PrintMatrixField(field);
                        if (GetPlayerOneWin(field))
                        {
                            Console.WriteLine("Player Two Win");
                        }
                    }
                }
            }
        }

        private static bool GetPlayerOneWin(char[,] field)
        {
            bool isWin = false;
            int count = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j]=='X')
                    {
                        count++;
                    }
                    else if (field[i,j]=='X' && field[i+1,j]=='X'&& field.GetLength(0)-1=='X')
                    {
                        count++;
                    }
                }

                if (count==3)
                {
                    return true;
                }
            }

            return isWin;
        }

        private static void PrintMatrixField(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i,j]+" ");
                }

                Console.WriteLine();
            }
        }

        private static bool GetValidIndexOfField(char[,] field, int row, int col)
        {
            bool isMoving = false;

            if (row >= 0 && row < field.Length - 1 && col >= 0 && col <= field.GetLength(1))
            {
                isMoving = true;
            }

            return isMoving;
        }

        private static void GetField(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string inputField = Console.ReadLine();

                for (int j = 0; j < inputField.Length; j++)
                {
                    field[i,j] = inputField[j];
                }
            }
        }
    }
}
