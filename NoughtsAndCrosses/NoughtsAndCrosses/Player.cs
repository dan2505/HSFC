using System;

namespace NoughtsAndCrosses
{
    public class Player
    {
        private readonly String name;
        private readonly Piece piece;

        public Player(String name, Piece piece)
        {
            this.name = name;
            this.piece = piece;
        }

        public Piece GetPieceAsPiece()
        {
            return piece;
        }

        public String GetPieceAsString()
        {
            if (piece == Piece.Nought) return "O";
            return "X";
        }

        public String GetName()
        {
            return name;
        }
    }
}
