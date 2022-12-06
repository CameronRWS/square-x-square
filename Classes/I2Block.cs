namespace Classes
{
    public class I2Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(1, 0), new (1, 1) }, //flat bar on bottom half
            new Position[] { new(0, 1), new (1, 1) }, //tall bar on right half
            new Position[] { new(0, 1), new (0, 0) }, //flat bar on top half
            new Position[] { new(1, 0), new (0, 0) }, //tall bar on left half

            //flipped
            new Position[] { new(0, 1), new (0, 0) }, //flat bar on top half
            new Position[] { new(1, 0), new (0, 0) }, //tall bar on left half
            new Position[] { new(1, 0), new (1, 1) }, //flat bar on bottom half
            new Position[] { new(0, 1), new (1, 1) }, //tall bar on right half
        };

        public I2Block(int id)
        {
            Id = id;
        }

        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;

    }
}
