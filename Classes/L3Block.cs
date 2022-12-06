namespace Classes
{
    public class L3Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(1, 0), new (0, 0), new(0, 1) }, //top left
            new Position[] { new(0, 0), new (0, 1), new(1, 1) }, //top right
            new Position[] { new(0, 1), new (1, 1), new(1, 0) }, //bottom right
            new Position[] { new(1, 1), new (1, 0), new(0, 0) }, //bottom left

            //flipped
            new Position[] { new(0, 0), new (0, 1), new(1, 1) }, //top right
            new Position[] { new(0, 1), new (1, 1), new(1, 0) }, //bottom right
            new Position[] { new(1, 1), new (1, 0), new(0, 0) }, //bottom left
            new Position[] { new(1, 0), new (0, 0), new(0, 1) }, //top left
        };

        public L3Block(int id)
        {
            Id = id;
        }

        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;

    }
}
