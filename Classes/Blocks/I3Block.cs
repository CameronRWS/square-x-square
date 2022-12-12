namespace Classes.Blocks
{
    public class I3Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(1, 0), new (1, 1), new(1, 2) }, //flat bar middle
            new Position[] { new(0, 1), new (1, 1), new(2, 1) }, //tall bar middle
            new Position[] { new(1, 0), new (1, 1), new(1, 2) }, //flat bar middle
            new Position[] { new(0, 1), new (1, 1), new(2, 1) }, //tall bar middle

            //flipped
            new Position[] { new(1, 0), new (1, 1), new(1, 2) }, //flat bar middle
            new Position[] { new(0, 1), new (1, 1), new(2, 1) }, //tall bar middle
            new Position[] { new(1, 0), new (1, 1), new(1, 2) }, //flat bar middle
            new Position[] { new(0, 1), new (1, 1), new(2, 1) }, //tall bar middle
        };

        public I3Block(int id)
        {
            Id = id;
        }

        protected override int BoundingBoxSize => 3;
        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;

    }
}
