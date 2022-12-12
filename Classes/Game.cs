

using Classes.Blocks;

namespace Classes;

public class Game
{

    private int[,] Grid { get; set; }

    public List<Block> BlocksPlaced { get; set; }

    public List<Block> BlocksToPlace { get; set; }

    //TODO: make property
    public int _rows = 6;
    public int _cols = 6;

    public Game()
    {
        Grid = new int[_rows, _cols];
        BlocksPlaced = new List<Block>();
        BlocksToPlace = new List<Block>() { new I4Block(1), new I3Block(2), new I2Block(3), new L3Block(4),
            new L4Block(5), new T4Block(6), new Z4Block(7), new O4Block(8) };




        InitializeGame(); //creates blocks that cant move.
    }

    public Game(Game x)
    {
        Grid = x.Grid;
        BlocksPlaced = new List<Block>();
        BlocksToPlace= new List<Block>();
        foreach (var b in x.BlocksToPlace)
        {
            BlocksToPlace.Add((Block)b.Clone());
        }
        foreach (var b in x.BlocksPlaced)
        {
            BlocksPlaced.Add((Block)b.Clone());
        }
    }

    public string GetColorOfTileAt(Position p)
    {
        return GetColor(Grid[p.Row, p.Column]);
    }

    public string GetColor(int id)
    {
        switch (id)
        {
            case 0:
                return "white";
            case 1:
                return "blue";
            case 2:
                return "green";
            case 3:
                return "red";
            case 4:
                return "purple";
            case 5:
                return "orange";
            case 6:
                return "teal";
            case 7:
                return "maroon";
            case 8:
                return "gray";
            default:
                return "black";
        }
    }

    public bool CheckLocationAndAddBlock(Block b)
    {
        if(IsBlockLocationValid(b))
        {
            AddBlock(b);
            return true; 
        } 
        return false;
    }

    private void AddBlock(Block b)
    {
        //Console.WriteLine("Adding block with Id: " + b.Id);
        foreach (var position in b.TilePositions())
        {
            //Console.WriteLine(position);
            Grid[position.Row, position.Column] = b.Id;
        }
        BlocksPlaced.Add(b);
        BlocksToPlace.Remove(b);
    }

    public Block RemoveBlockAtPosition(Position p)
    {
        foreach(var b in BlocksPlaced)
        {
            foreach(var pos in b.TilePositions())
            {
                if(p.Row == pos.Row && p.Column == pos.Column)
                {
                    return RemoveBlock(b);
                }
            }
        }
        return null!;
    }

    private Block RemoveBlock(Block b)
    {
        if (b.Id == 9) return null;
        //Console.WriteLine("Removing block with Id: " + b.Id);
        foreach(var pos in b.TilePositions())
        {
            Grid[pos.Row, pos.Column] = 0;
        }
        BlocksToPlace.Add(b);
        BlocksPlaced.Remove(b);
        return b;
    }

    public bool IsBlockInBounds(Block b)
    {
        foreach (var position in b.TilePositions())
        {
            if (!IsPositionInBounds(position))
            {
                //Console.WriteLine("Selected block location for " + b + " was invalid due to being out of bounds.");
                return false;
            }
        }
        return true;
    }

    public bool IsBlockClearToPlace(Block b)
    {
        foreach (var position in b.TilePositions())
        {
            if (Grid[position.Row, position.Column] != 0)
            {
                //Console.WriteLine("Selected block location for " + b + " was invalid due to block collision");
                //Console.WriteLine(position + " has the value of: " + Grid[position.Row, position.Column]);
                return false;
            }
        }
        return true;
    }

    public bool IsBlockLocationValid(Block b)
    {
        if(!IsBlockInBounds(b)) return false;
        if(!IsBlockClearToPlace(b)) return false;
        //Console.WriteLine("Selected block location for " + b + " was valid.");
        return true;
    }

    public bool IsPositionInBounds(Position p)
    {
        if (p.Column <= -1 || p.Column >= this._cols || p.Row <= -1 || p.Row >= this._rows)
        {
            return false;
        }
        return true;
    }

    override public string ToString()
    {
        String s = string.Empty;
        for(int r = 0; r < _rows; r++)
        {
            s += "[";
            for (int c = 0; c < _cols; c++)
            {
                s = s + Grid[r, c] + ", ";
            }
            s = s.Substring(0, s.Length - 2);
            s += "]," + "\n";
        }
        return s;
    }

    public Block GetNextBlockToPlace(Block b)
    {
        int elementIndex = BlocksToPlace.IndexOf(b);
        if (elementIndex == BlocksToPlace.Count - 1) return BlocksToPlace[0];
        return BlocksToPlace[elementIndex + 1];
    }

    public Block GetPrevBlockToPlace(Block b)
    {
        int elementIndex = BlocksToPlace.IndexOf(b);
        if (elementIndex == 0) return BlocksToPlace[BlocksToPlace.Count - 1];
        return BlocksToPlace[elementIndex - 1];
    }

    public List<Block> GetLegalMoves() 
    {
        var legalMoves = new List<Block>();
        foreach(var b in BlocksToPlace)
        {
            AppendLegalMovesForBlock(b, legalMoves);
        }
        Random rng = new Random();
        return legalMoves.OrderBy(a => rng.Next()).ToList(); ;
    }

    //public void PrintAllLegalMoves()
    //{
    //    foreach(var b in GetLegalMoves())
    //    {
    //        Console.WriteLine(b);
    //        var actualBlockRef = BlocksToPlace.Find(x => x.Id == b.Id);
    //        actualBlockRef.Move(b.offset.Column, b.offset.Row);
    //        if(CheckLocationAndAddBlock(actualBlockRef))
    //        {
    //            Console.WriteLine(this);
    //            RemoveBlock(actualBlockRef);
    //            Console.WriteLine("------------------------------------");
    //        } else
    //        {
    //            Console.WriteLine("Was invalid somehow, ie get legal moves returns invalid moves");
    //        }

    //    }
    //}
    
    public void AppendLegalMovesForBlock(Block b, List<Block> legalMoves)
    {
        for(int x = -1; x <= 6; x++)
        {
            for (int y = -1; y <= 6; y++)
            {
                for(int f = 0; f <= 1; f++) // 2 flip states
                {
                    for(int r = 0; r <= 3; r++) // 4 rotation states
                    {
                        Block temp = (Block)b.Clone();
                        temp.flipState = f;
                        temp.rotationState = r;
                        temp.offset = new Position(x, y);
                        if (IsBlockLocationValid(temp) && !IsBlockLocationDuplicate(temp, legalMoves))
                        {
                            legalMoves.Add(temp);
                        }
                    }
                }
            }
        }
    }

    public bool IsBlockLocationDuplicate(Block temp, List<Block> legalMoves)
    {
        foreach(Block b in legalMoves)
        {
            if(b.Equals(temp)) return true;
        }
        return false;
    }

    public Game Solve()
    {
        if(BlocksToPlace.Count == 0)
        {
            return this;
        }

        if (!IsPromising())
        {
            return null;
        }

        if (BlocksToPlace.Count <= 1)
        {
            Console.WriteLine("Attempting to solve: \n" + this);
            Console.WriteLine(BlocksPlaced.Count + " blocks placed out of 14");
        }

        foreach(var move in this.GetLegalMoves())
        {
            var gs = new Game(this);

            var actualBlockRef = gs.BlocksToPlace.Find(x => x.Id == move.Id);
            actualBlockRef.Move(move.offset.Row, move.offset.Column);

            if (gs.CheckLocationAndAddBlock(actualBlockRef))
            {
                var solved = gs.Solve();
                if (solved != null) return solved;
                gs.RemoveBlock(actualBlockRef);
            }
            else
            {
                //Console.WriteLine("Was invalid somehow, ie get legal moves returns invalid moves");
            }
        }
        return null;
    }

    public void PrintSolved()
    {
        Game solved = this.Solve();
        Console.WriteLine("Solved: \n" + solved);
    }

    public bool IsPromising()
    {
        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _cols; c++)
            {
                if(Grid[r, c] == 0)
                {
                    var p = new Position(r, c);
                    if(IsEmptySpaceSurrounded(p)) 
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public bool IsEmptySpaceSurrounded(Position p)
    {
        var surroundingPositions = new List<Position>
        {
            new(p.Row, p.Column+1),
            new(p.Row, p.Column-1),
            new(p.Row+1, p.Column),
            new(p.Row-1, p.Column)
        };
        foreach (var sp in surroundingPositions)
        {
            if(IsPositionInBounds(sp))
            {
                if (Grid[sp.Row, sp.Column] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }








    //delete this ugly
    public void InitializeGame()
    {
        var l = new List<Block>();
        var b1 = new O1Block(9);
        b1.Move(4, 2);
        var b2 = new O1Block(9);
        b2.Move(4, 3);
        var b3 = new O1Block(9);
        b3.Move(3, 2);
        var b4 = new O1Block(9);
        b4.Move(3, 3);
        var b5 = new I2Block(9);
        b5.Move(2, 0);
        b5.RotateCW();
        var b6 = new I2Block(9);
        b6.Move(2, 3);
        b6.RotateCW();
        //this.CheckLocationAndAddBlock(b1);
        //this.CheckLocationAndAddBlock(b2);
        //this.CheckLocationAndAddBlock(b3);
        //this.CheckLocationAndAddBlock(b4);
        //this.CheckLocationAndAddBlock(b5);
        //this.CheckLocationAndAddBlock(b6);
    }
}