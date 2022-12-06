namespace Classes
{
    public class L4Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(2, 0), new (1, 0), new(1, 1), new(1, 2) }, //L down
            new Position[] { new(0, 0), new (0, 1), new(1, 1), new(2, 1) }, //L upside down
            new Position[] { new(0, 2), new (1, 2), new(1, 1), new(1, 0) }, //L up
            new Position[] { new(2, 2), new (2, 1), new(1, 1), new(0, 1) }, //L normal

            //flipped
            new Position[] { new(2, 2), new (1, 0), new(1, 1), new(1, 2) }, //J basically to the right
            new Position[] { new(2, 0), new (0, 1), new(1, 1), new(2, 1) }, //J normal
            new Position[] { new(0, 0), new (1, 2), new(1, 1), new(1, 0) }, //J left i guess
            new Position[] { new(0, 2), new (2, 1), new(1, 1), new(0, 1) }, //J upside down
        };

        public L4Block(int id)
        {
            Id = id;
        }

        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;

    }
}
