namespace Classes.Blocks
{
    public class I4Block : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //non-flipped
            new Position[] { new(1, 0), new (1, 1), new(1, 2), new(1,3) }, //flat bar on top half
            new Position[] { new(0, 2), new (1, 2), new(2, 2), new(3,2) }, //tall bar on right half
            new Position[] { new(2, 0), new (2, 1), new(2, 2), new(2,3) }, //flat bar on bottom half
            new Position[] { new(0, 1), new (1, 1), new(2, 1), new(3,1) }, //tall bar on left half
            //flipped
            new Position[] { new(2, 0), new (2, 1), new(2, 2), new(2,3) }, //flat bar on bottom half
            new Position[] { new(0, 1), new (1, 1), new(2, 1), new(3,1) }, //tall bar on left half
            new Position[] { new(1, 0), new (1, 1), new(1, 2), new(1,3) }, //flat bar on top half
            new Position[] { new(0, 2), new (1, 2), new(2, 2), new(3,2) }  //tall bar on right half
        };

        public I4Block(int id)
        {
            Id = id;
        }

        protected override int BoundingBoxSize => 4;
        protected override Position StartOffset => new Position(0, 0);

        protected override Position[][] Tiles => tiles;
    }
}
