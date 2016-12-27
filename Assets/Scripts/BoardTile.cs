using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using System.Collections;

//Basic data structure to store information about a single tile
public class BoardTile : MonoBehaviour{
    public enum Directions : byte { E, SE, SW, W, NW, NE };
    private int x;
    private int y;
    private GameObject[] adjTiles;
    private BoardManager parent;
    private GameObject content;

    //Called on instantiation
    public void Start()
    {
        adjTiles = new GameObject[6];
        parent = BoardManager.GetBoardManager();
    }

    public void SetCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }
    

    //Method to set the array of adjacent tiles given a board
    public void UpdateAdjacentTiles()
    {
        /* Wrap around the western neighbor */
        adjTiles[0] = parent.GetTile(x + 1 % BoardManager.WIDTH, y);

        /* If the tile is along the bottom row, don't add the southern neighbors */
        if(y - 1 >= 0)
        {
            adjTiles[1] = parent.GetTile(x + 1, y - 1);
            adjTiles[2] = parent.GetTile(x, y - 1);
        } else
        {
            adjTiles[1] = null;
            adjTiles[2] = null;
        }

        /* Wrap around the eastern neighbor */
        if (x != 0)
        {
            adjTiles[3] = parent.GetTile(x - 1, y);
        } else
        {
            adjTiles[3] = parent.GetTile(BoardManager.WIDTH - 1, y);
        }

        /* If the tile is along the top row, don't add the northern neighbors */
        if(y + 1 < BoardManager.HEIGHT)
        {
            adjTiles[4] = parent.GetTile(x - 1, y + 1);
            adjTiles[5] = parent.GetTile(x, y + 1);
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
            GameObject temp = adjTiles[(dir + i) % adjTiles.Length];
            if(temp != null) { result.Add(temp); }
        }
        return result;
    }
}
