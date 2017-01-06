using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class BoardTile : MonoBehaviour {
    public enum Directions : byte { E, SE, SW, W, NW, NE };
    public int x;
    public int y;
    public BoardTile[] adjTiles;
    public BoardManager parent;

    public BoardTile(int x, int y, BoardManager parent)
    {
        this.x = x;
        this.y = y;
        this.parent = parent;
    }

    public void updateAdjacentTiles()
    {

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
