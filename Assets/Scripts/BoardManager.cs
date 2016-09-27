using UnityEngine;
using System.Collections;

//Script that handles the logic of creating and store the game board
public class BoardManager : MonoBehaviour {

    private static BoardManager boardManager;

    public const int WIDTH = 16;
    public const int HEIGHT = 7;
    private BoardTile[,] board;

	// Use this for initialization
	void Start () {
        board = new BoardTile[WIDTH, HEIGHT];
        for(int x = 0; x < WIDTH; x++)
        {
            for(int y = 0; y < HEIGHT; y++)
            {
                board[x, y] = new BoardTile(x, y, this);
            }
        }
        for(int x = 0; x < WIDTH; x++)
        {
            for(int y = 0; y < HEIGHT; y++)
            {
                board[x, y].updateAdjacentTiles();
            }
        }
	}

    public BoardTile getTile(int x, int y)
    {
        return board[x, y];
    }

    public static BoardManager getBoardManager()
    {
        if(boardManager)
        {
            return boardManager;
        } else
        {
            boardManager = new BoardManager();
            return boardManager;
        }
    }
}
