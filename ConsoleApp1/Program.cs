using ConsoleApp1.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        private static int _playerCount;
        private static int _lineWidth;
        static void Main(string[] args)
        {
            GetStartVariables();
        }

        private static void GetStartVariables()
        {
            Console.Clear();
            Console.WriteLine("Welkom");
            Console.Write("Lijnbreedte (standaard = 4): ");
            var readKeyLineWidth = Console.ReadKey();
            Console.WriteLine();
            Console.Write("Aantal spelers (standaard = 2): ");
            var readKeyPlayerCount = Console.ReadKey();
            Console.WriteLine();

            if (readKeyLineWidth.KeyChar == 13 && readKeyPlayerCount.KeyChar == 13)
            {
                _lineWidth = 4;
                _playerCount = 2;
                StartGame(_lineWidth, _playerCount);
            } 
            else if (int.TryParse(readKeyLineWidth.KeyChar.ToString(), out _lineWidth) &&
                int.TryParse(readKeyPlayerCount.KeyChar.ToString(), out _playerCount))
            {
                StartGame(_lineWidth, _playerCount);
            }
            else
            {
                Console.WriteLine("Incorrect settings, please try again...");
                Console.ReadKey();
                GetStartVariables();
            }
        }

        public static void StartGame(int lineWidth, int playerCount)
        {
            var grid = new Grid(lineWidth);
            int x, y;
            List<int> winningPositions;
            var player = 1;
            var position = 0;
            while (true)
            {
                Console.Clear();
                Console.Write(grid.Draw());
                Console.WriteLine("Player: " + player);
                Console.Write("Kolom: ");
                var readKeyX = Console.ReadKey();
                Console.WriteLine();
                if (readKeyX.KeyChar == 'q')
                {
                    break;
                }
                Console.Write("Rij: ");
                var readKeyY = Console.ReadKey();
                Console.WriteLine();
                if (!int.TryParse(readKeyX.KeyChar.ToString(), out x) ||
                    !int.TryParse(readKeyY.KeyChar.ToString(), out y)) continue;

                if (grid.MakeMove(x - 1, y - 1, player, out position))
                {
                    
                    if (grid.HasWinner(position, out winningPositions))
                    {
                        Console.Clear();
                        Console.Write(grid.Draw(winningPositions));
                        Console.WriteLine();
                        Console.WriteLine($"Player {player} has won!!!");
                        var readLine = Console.ReadLine();
                        if (readLine != null && readLine.StartsWith("r"))
                        {
                            StartGame(_lineWidth,_playerCount);
                        }
                        break;
                    }
                    player++;
                    if (player > _playerCount)
                    {
                        player = 1;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move, please try again...");
                    Console.ReadKey();
                }
            }
        }
    }
}
