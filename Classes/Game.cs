

using Microsoft.AspNetCore.Components.Web;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

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
        Console.WriteLine("Adding block with Id: " + b.Id);
        foreach (var position in b.TilePositions())
        {
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
        return null;
    }

    private Block RemoveBlock(Block b)
    {
        if (b.Id == -1) return null;
        Console.WriteLine("Removing block with Id: " + b.Id);
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
                Console.WriteLine("Selected block location for " + b + " was invalid due to being out of bounds.");
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
                Console.WriteLine("Selected block location for " + b + " was invalid due to block collision");
                Console.WriteLine(position + " has the value of: " + Grid[position.Row, position.Column]);
                return false;
            }
        }
        return true;
    }

    public bool IsBlockLocationValid(Block b)
    {
        if(!IsBlockInBounds(b)) return false;
        if(!IsBlockClearToPlace(b)) return false;
        Console.WriteLine("Selected block location for " + b + " was valid.");
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










    //delete this ugly
    public void InitializeGame()
    {
        var l = new List<Block>();
        var b1 = new O1Block(-1);
        b1.Move(4, 2);
        var b2 = new O1Block(-1);
        b2.Move(4, 3);
        var b3 = new O1Block(-1);
        b3.Move(3, 2);
        var b4 = new O1Block(-1);
        b4.Move(3, 3);
        var b5 = new I2Block(-1);
        b5.Move(2, 0);
        b5.RotateCW();
        var b6 = new I2Block(-1);
        b6.Move(2, 3);
        b6.RotateCW();
        this.CheckLocationAndAddBlock(b1);
        this.CheckLocationAndAddBlock(b2);
        this.CheckLocationAndAddBlock(b3);
        this.CheckLocationAndAddBlock(b4);
        this.CheckLocationAndAddBlock(b5);
        this.CheckLocationAndAddBlock(b6);
    }
}