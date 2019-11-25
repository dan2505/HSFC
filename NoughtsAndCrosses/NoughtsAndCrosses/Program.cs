using System;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            OXO oxo = new OXO();

            oxo.GenerateGrid();
            Console.ReadLine();
        }
    }
}
