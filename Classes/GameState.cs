

using System.Collections;
using System.ComponentModel;
using System.Data;

namespace Classes;

public class GameState
{

    private int[,] Grid { get; set; }

    private List<Block> BlocksPlaced { get; set; }

    private int _rows = 6;
    private int _cols = 6;

    public GameState()
    {
        Grid = new int[_rows, _cols];
        BlocksPlaced = new List<Block>();
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
        foreach (var position in b.TilePositions())
        {
            Grid[position.Row, position.Column] = b.Id;
        }
        BlocksPlaced.Add(b);
    }

    public void RemoveBlockAtPosition(Position p)
    {
        foreach(var b in BlocksPlaced)
        {
            foreach(var pos in b.TilePositions())
            {
                if(p.Row == pos.Row && p.Column == pos.Column)
                {
                    RemoveBlock(b);
                    return;
                }
            }
        }
    }

    private void RemoveBlock(Block b)
    {
        foreach(var pos in b.TilePositions())
        {
            Grid[pos.Row, pos.Column] = 0;
        }
    }

    public bool IsBlockLocationValid(Block b)
    {
        foreach(var position in b.TilePositions())
        {
            if (Grid[position.Row, position.Column] != 0)
            {
                return false;
            }
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
}