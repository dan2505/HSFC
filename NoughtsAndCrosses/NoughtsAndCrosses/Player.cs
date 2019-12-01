namespace NoughtsAndCrosses
{
    public class Player
    {
        private readonly string name;
        private readonly Piece piece;
        private int moves;

        public Player(string name, Piece piece)
        {
            this.name = name;
            this.piece = piece;
        }

        public string GetPieceAsString()
        {
            return piece == Piece.Nought ? "O" : "X";
        }

        public string GetName()
        {
            return name;
        }

        public void BumpMoves()
        {
            moves += 1;
        }

        public int GetMoves()
        {
            return moves;
        }
    }
}
