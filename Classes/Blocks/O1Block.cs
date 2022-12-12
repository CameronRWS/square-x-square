namespace Classes.Blocks
{
    public class O1Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(0, 0) },
            new Position[] { new(0, 0) },
            new Position[] { new(0, 0) },
            new Position[] { new(0, 0) },

            //flipped
            new Position[] { new(0, 0) },
            new Position[] { new(0, 0) },
            new Position[] { new(0, 0) },
            new Position[] { new(0, 0) }
        };

        public O1Block(int id)
        {
            Id = id;
        }

        protected override int BoundingBoxSize => 1;
        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;

    }
}
