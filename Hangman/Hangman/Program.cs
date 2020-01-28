using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman game = new Hangman();
            while (game.getStatus())
            {
                Console.WriteLine(game.getReveal());
                char character = Console.ReadKey().KeyChar;
                Console.WriteLine();
                game.makeGuess(character);
            }
        }
    }
}
