using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using System.Collections;

//Basic data structure to store information about a single tile
public class BoardTile : MonoBehaviour {
    public enum Directions : byte { E, SE, SW, W, NW, NE };
    public int x;
    public int y;
    public BoardTile[] adjTiles;
    public BoardManager parent;
    public Entity content;

    //Events
    public UnityEvent enterTile;
    public UnityEvent leaveTile;

    public BoardTile(int x, int y, BoardManager parent)
    {
        this.x = x;
        this.y = y;
        this.adjTiles = new BoardTile[6];
        this.parent = parent;
        enterTile = new UnityEvent();
        leaveTile = new UnityEvent();
    }

    //Method to set the array of adjacent tiles given a board
    public void updateAdjacentTiles()
    {
        adjTiles[0] = parent.getTile(x + 1, y);
        if(y - 1 >= 0)
        {
            adjTiles[1] = parent.getTile(x + 1, y - 1);
            adjTiles[2] = parent.getTile(x, y - 1);
        } else
        {
            adjTiles[1] = null;
            adjTiles[2] = null;
        }
        adjTiles[3] = parent.getTile(x - 1, y);
        if(y + 1 < BoardManager.HEIGHT)
        {
            adjTiles[4] = parent.getTile(x - 1, y + 1);
            adjTiles[5] = parent.getTile(x, y + 1);
        } else
        {
            adjTiles[4] = null;
            adjTiles[5] = null;
        }
    }

    //Method should be called with the leftmost direction of the arc as dir, and 
    public ArrayList getAdjacentArc(byte dir, int size)
    {
        //Asserts that size is valid
        Assert.IsTrue(0 < size && size <= adjTiles.Length);

        ArrayList result = new ArrayList();
        for(int i = 0; i < size; i++)
        {
            BoardTile temp = adjTiles[(dir + i) % adjTiles.Length];
            if(temp != null) { result.Add(temp); }
        }
        return result;
    }
}
