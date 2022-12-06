namespace Classes
{
    public class O4Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },

            //flipped
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) }
        };

        public O4Block(int id)
        {
            Id = id;
        }

        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;

    }
}
