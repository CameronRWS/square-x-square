namespace Classes
{
    public class Z4Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(2, 0), new (1, 0), new(1, 1), new(0, 1) }, //z up
            new Position[] { new(0, 0), new (0, 1), new(1, 1), new(1, 2) }, //z sideways on the top
            new Position[] { new(0, 2), new (1, 2), new(1, 1), new(2, 1) }, //z down on right side
            new Position[] { new(2, 2), new (2, 1), new(1, 1), new(1, 0) }, //z on floor

            //flipped
            new Position[] { new(2, 2), new (1, 2), new(1, 1), new(0, 1) },
            new Position[] { new(2, 0), new (2, 1), new(1, 1), new(1, 2) },
            new Position[] { new(0, 0), new (1, 0), new(1, 1), new(2, 1) },
            new Position[] { new(0, 2), new (0, 1), new(1, 1), new(1, 0) }
        };

        public Z4Block(int id)
        {
            Id = id;
        }

        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;

    }
}
