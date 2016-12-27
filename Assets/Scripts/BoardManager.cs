using UnityEngine;
using System.Collections;


//Script that handles the logic of creating and store the game board
public class BoardManager : MonoBehaviour {

    private static BoardManager boardManager;

    /* Board constants */
    public const int WIDTH = 16;
    public const int HEIGHT = 7;
    public const float TILE_SIZE = 1.0f;

    /* Main Board data structure */
    private GameObject[,] board;

    /* Anchor point used to orient the board */
    private int anchorX = 0;

    /* Base game tile */
    public GameObject tile;
	
	void Start () {

        //Initialize the tiles in the board
        board = new GameObject[WIDTH, HEIGHT];
        for(int x = 0; x < WIDTH; x++)
        {
            for(int y = 0; y < HEIGHT; y++)
            {
                float xPos = (x + (y / 2.0f)) * TILE_SIZE;
                float yPos = y * TILE_SIZE / Mathf.Sqrt(3.0f);

                board[x, y] = (GameObject)Instantiate(tile, new Vector3(xPos, yPos), Quaternion.identity, this.transform);
                board[x, y].GetComponent<BoardTile>().SetCoordinates(x, y);
            }
        }

        //Initialize their adjacency lists
        for(int x = 0; x < WIDTH; x++)
        {
            for(int y = 0; y < HEIGHT; y++)
            {
                board[x, y].GetComponent<BoardTile>().UpdateAdjacentTiles();
            }
        }
        
	}

    public GameObject GetTile(int x, int y)
    {
        return board[x, y];
    }

    public void UpdateTileLocations(int newAnchorX)
    {
        foreach(GameObject tile in board)
        {
            UpdateTilePos(tile, newAnchorX);
        }
    }

    public void UpdateTilePos(GameObject tile, int newAnchorX)
    {
        BoardTile tileComponent = tile.GetComponent<BoardTile>();
        anchorX = newAnchorX;
        float horizOffset = (tileComponent.getX() + (tileComponent.getY() / 2.0f)) - anchorX;

        if (horizOffset < 0)
        {
            horizOffset += WIDTH;
        }
        float xOffset = horizOffset * TILE_SIZE;
        float yOffset = tileComponent.getY() * TILE_SIZE / Mathf.Sqrt(3.0f);
        tile.transform.position = board[anchorX, 0].transform.position + new Vector3(xOffset, yOffset, 0.0f);
    }

    public static BoardManager GetBoardManager()
    {
        if(boardManager)
        {
            return boardManager;
        } else
        {
            boardManager = new BoardManager();
            DontDestroyOnLoad(boardManager);
            return boardManager;
        }
    }
}
