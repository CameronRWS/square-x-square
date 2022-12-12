
namespace Classes.Blocks
{
    public abstract class Block : ICloneable
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }

        public int Id { get; set; }

        protected abstract int BoundingBoxSize { get; }

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
            foreach (Position p in Tiles[rotationState + flipState * 4])
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
            if (rotationState == 0)
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

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            //TODO: add this back sometime?
            //if (obj.GetType() != typeof(Block)) return false;
            Block b = (Block) obj;
            
            if(b.Id != this.Id) return false;
            //if(b.flipState!= this.flipState) return false;
            //if(b.offset.Equals(this.offset)) return false;
            //if(b.rotationState!= this.rotationState) return false;

            //check if the two sets of positions are essentially the same, maybe in different order.
            foreach(var p in this.TilePositions()) 
            {
                bool foundMatch = false;
                foreach(var comparedPos in b.TilePositions())
                {
                    if(p.Equals(comparedPos))
                    {
                        foundMatch = true;
                        break;
                    }
                }
                if (!foundMatch) return false;
            }
            return true;
        }

        public object Clone()
        {
            Block b = (Block)MemberwiseClone();
            b.offset = this.offset.Clone();
            return b;
        }

        public override string ToString()
        {
            return GetType().Name + ": " + offset.ToString() + ", r: " + rotationState + ", f: " + flipState;
        }
    }
}
