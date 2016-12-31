using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using System.Collections;

//Basic data structure to store information about a single tile
public class BoardTile : MonoBehaviour{
    public enum Directions : byte { E, SE, SW, W, NW, NE };
    private GameObject[] adjTiles;

    public GameObject content;
    public int x;
    public int y;

    //Called on instantiation
    public void Awake()
    {
        adjTiles = new GameObject[6];
    }
 
    //Method to set the array of adjacent tiles given a board
    public void UpdateAdjacentTiles()
    {
        BoardManager boardManager = BoardManager.GetBoardManager();

        /* Wrap around the western neighbor */
        adjTiles[0] = boardManager.GetTile(Util.Mod(x + 1, BoardManager.WIDTH), y);

        /* If the tile is along the bottom row, don't add the southern neighbors */
        if(y - 1 >= 0)
        {
            adjTiles[1] = boardManager.GetTile(Util.Mod(x + 1, BoardManager.WIDTH), y - 1);
            adjTiles[2] = boardManager.GetTile(x, y - 1);
        } else
        {
            adjTiles[1] = null;
            adjTiles[2] = null;
        }

        /* Wrap around the eastern neighbor */
        adjTiles[3] = boardManager.GetTile(Util.Mod(x - 1, BoardManager.WIDTH), y);


        /* If the tile is along the top row, don't add the northern neighbors */
        if(y + 1 < BoardManager.HEIGHT)
        {
            adjTiles[4] = boardManager.GetTile(Util.Mod(x - 1, BoardManager.WIDTH), y + 1);
            adjTiles[5] = boardManager.GetTile(x, y + 1);
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
