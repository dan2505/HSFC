using System;

namespace NoughtsAndCrosses
{
    class OXO
    {
        private readonly string[] game = new string[10];
        private readonly Player[] players = new Player[2];

        private readonly bool running = true;
        private readonly int current;

        private readonly Random rand = new Random();

        private int total;

        public OXO(Player first, Player second)
        {
            players[0] = first; // Crosses player.
            players[1] = second; // Noughts player.
            current = rand.Next(0, 2); // Randomly choose a player to go first.
            ResetGrid();
            GenerateGrid();

            while (running)
            {
                PiecePlacement();
                current = 1 - current;
                running &= !WinChecker();
                GenerateGrid();
            }

            if (total >= 9)
            {
                Console.WriteLine("This match has been a draw! Congratulations both!");
                return;
            }

            Player winner = players[1 - current];
            Console.WriteLine("{0} is our winner after {1} moves! Congratulations!", winner.GetName(), winner.GetMoves());
        }

        private void GenerateGrid()
        {
            Console.Clear();
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", game[1], game[2], game[3]);
            Console.WriteLine("       |       |       ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", game[4], game[5], game[6]);
            Console.WriteLine("       |       |       ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", game[7], game[8], game[9]);
            Console.WriteLine("       |       |       ");
            Console.WriteLine("");
        }

        private void ResetGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                game[i] = Convert.ToString(i);
            }
        }

        private void PiecePlacement()
        {
            while (true)
            {
                Player playing = players[current];

                Console.WriteLine("Where would you like to go, {0}? (#{1})", playing.GetName(), playing.GetMoves());
                int selection = Convert.ToInt32(Console.ReadLine());

                if (selection > game.Length - 1 || selection < 1)
                {
                    Console.WriteLine("Choose a location between 1 & 9.");
                    continue;
                }
                if (game[selection] != "O" && game[selection] != "X")
                {
                    game[selection] = playing.GetPieceAsString();

                    playing.BumpMoves();

                    total += 1;
                    break;
                }

                Console.WriteLine("There is already a piece here! Try another location.");
                continue;
            }
        }

        private bool WinChecker()
        {
            return
                // Draw checks.
                total >= 9 ||
                // Horizontal line checks.
                LineChecker(1, 1) || // First row of grid.
                LineChecker(4, 1) || // Second row of grid.
                LineChecker(7, 1) || // Third row of grid.
                // Vertical line checks.
                LineChecker(1, 3) || // First column of grid.
                LineChecker(2, 3) || // Second column of grid.
                LineChecker(3, 3) || // Third column of grid.
                // Diagonal checks.
                LineChecker(1, 4) || // Top left to bottom right.
                LineChecker(3, 2); // Top right to bottom left.
        }

        private bool LineChecker(int loc1, int loc2, int loc3, string piece)
        {
            return (game[loc1] == piece) && (game[loc2] == piece) && (game[loc3] == piece);
        }

        private bool LineChecker(int loc1, int jump)
        {
            return LineChecker(loc1, loc1 + jump, loc1 + (jump * 2), game[loc1]);
        }
    }
}