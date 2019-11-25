using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    class OXO
    {
        public enum Piece {Space, Nought, Cross};
        public Piece[,] game = new Piece[3,3];

        public void GenerateGrid()
        {
            Console.WriteLine("       |       |       ");
            Console.WriteLine("  {0}    |  {1}    |   {2}   ", GetPiece(game[0,0]), GetPiece(game[0, 1]), GetPiece(game[0, 2]));
            Console.WriteLine("       |       |       ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("  {0}    |  {1}    |   {2}   ", GetPiece(game[1, 0]), GetPiece(game[1, 1]), GetPiece(game[1, 2]));
            Console.WriteLine("       |       |       ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("  {0}    |  {1}    |   {2}   ", GetPiece(game[2, 0]), GetPiece(game[2, 1]), GetPiece(game[2, 2]));
            Console.WriteLine("       |       |       ");
        }

        public String GetPiece(Piece piece)
        {
           switch(piece) {
                case Piece.Cross:
                    return "X";
                case Piece.Nought:
                    return "O";
                default:
                    return " ";
            }
        }
    }
}
