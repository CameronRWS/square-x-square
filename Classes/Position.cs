namespace Classes
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return "(" + Row + "," + Column + ")";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != typeof(Position)) return false;

            return this.Column == ((Position)obj).Column && this.Row == ((Position)obj).Row;
        }
    }
}
