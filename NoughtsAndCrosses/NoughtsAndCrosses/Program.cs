using System;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Noughts and Crosses!");

            Console.WriteLine("What is the first player's name?");
            Player first = new Player(Console.ReadLine(), Piece.Cross);

            Console.WriteLine("What is the second player's name?");
            Player second = new Player(Console.ReadLine(), Piece.Nought);

            Console.WriteLine(first.GetName() + " will be Crosses - X");
            Console.WriteLine(second.GetName() + " will be Noughts - O");

            Console.WriteLine("Press enter to begin game!");
            Console.ReadLine();

            _ = new OXO(first, second);
            Console.ReadLine();
        }
    }
}
