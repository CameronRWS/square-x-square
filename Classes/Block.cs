using MudBlazor;

namespace Classes
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; } 

        public int Id { get; set; }

        //TODO: make properties
        public int rotationState;
        public int flipState;

        public Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach(Position p in Tiles[rotationState + (flipState*4)])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % 4;
        }

        public void RotateCCW()
        {
            if(rotationState == 0)
            {
                rotationState = 4 - 1;
            } 
            else
            {
                rotationState--;
            }
        }

        public void Flip()
        {
            flipState = (flipState + 1) % 2;
        }

        public void Move(int rows, int cols)
        {
            offset.Row = rows;
            offset.Column = cols;
        }

        public void Reset()
        {
            rotationState = 0;
            flipState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
