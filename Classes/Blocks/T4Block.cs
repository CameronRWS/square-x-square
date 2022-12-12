namespace Classes.Blocks
{
    public class T4Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(2, 1), new (1, 0), new(1, 1), new(1, 2) }, //T pointing down
            new Position[] { new(1, 0), new (0, 1), new(1, 1), new(2, 1) }, //T pointing left
            new Position[] { new(0, 1), new (1, 0), new(1, 1), new(1, 2) }, //T pointing up
            new Position[] { new(1, 2), new (0, 1), new(1, 1), new(2, 1) }, //T pointing right

            //flipped
            new Position[] { new(0, 1), new (1, 0), new(1, 1), new(1, 2) }, //T pointing up
            new Position[] { new(1, 2), new (0, 1), new(1, 1), new(2, 1) }, //T pointing right
            new Position[] { new(2, 1), new (1, 0), new(1, 1), new(1, 2) }, //T pointing down
            new Position[] { new(1, 0), new (0, 1), new(1, 1), new(2, 1) }, //T pointing left
        };

        public T4Block(int id)
        {
            Id = id;
        }

        protected override int BoundingBoxSize => 3;

        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;


    }
}
