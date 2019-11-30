namespace NoughtsAndCrosses
{
    public class Player
    {
        private readonly string name;
        private readonly Piece piece;

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
    }
}
