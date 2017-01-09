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
    private GameObject tile;
	
	void Start () {

       if(boardManager == null)
        {
            boardManager = this;
            DontDestroyOnLoad(boardManager);
        }

        //Get the base tile
        tile = (GameObject)Resources.Load("BaseTile");

        //Initialize the tiles in the board
        board = new GameObject[WIDTH, HEIGHT];
        for(int x = 0; x < WIDTH; x++)
        {
            for(int y = 0; y < HEIGHT; y++)
            {
                float xCoord = (x + (y / 2.0f));

                //Wrap around tiles that overflow on the east
                if(xCoord >= WIDTH)
                {
                    xCoord -= WIDTH;
                }
                float xPos = xCoord * TILE_SIZE;
                float yPos = y * TILE_SIZE;

                board[x, y] = (GameObject)Instantiate(tile, new Vector3(xPos, yPos), Quaternion.identity, this.transform);
                board[x, y].GetComponent<BoardTile>().x = x;
                board[x, y].GetComponent<BoardTile>().y = y;
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

    public void HighlightTile(int x, int y)
    {
        board[x, y].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.grey);
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
        float horizOffset = (tileComponent.x + (tileComponent.y / 2.0f)) - anchorX;

        if (horizOffset < 0)
        {
            horizOffset += WIDTH;
        }
        float xOffset = horizOffset * TILE_SIZE;
        float yOffset = tileComponent.y * TILE_SIZE;
        tile.transform.position = board[anchorX, 0].transform.position + new Vector3(xOffset, yOffset, 0.0f);
    }

    public bool AddEntity(GameObject target, int x, int y) 
    {
        Entity entity = target.GetComponent<Entity>();
        Debug.Assert(entity != null);
        BoardTile tileComponent = board[x, y].GetComponent<BoardTile>();
        if(tileComponent.content == null)
        {
            tileComponent.content = target;
            entity.SetX(x);
            entity.SetY(y);
            entity.transform.SetParent(tileComponent.transform);           
            return true;
        } else
        {
            return false;
        }
    }

    public bool RemoveEntity(int x, int y)
    {
        BoardTile tileComponent = board[x, y].GetComponent<BoardTile>();
        if(tileComponent.content != null)
        {
            Destroy(tileComponent.content);
            return true;
        } else
        {
            return false;
        }
    }

    public bool RemoveEntity(GameObject target)
    {
        Debug.Assert(target.GetComponent<Entity>() != null);
        Entity targetEnt = target.GetComponent<Entity>();
        return RemoveEntity(targetEnt.GetX(), targetEnt.GetY());
    }

    public static BoardManager GetBoardManager()
    {
        if(boardManager)
        {
            return boardManager;
        } else
        {
            GameObject boardManagerObj = new GameObject("BoardManager");
            boardManager = boardManagerObj.AddComponent<BoardManager>().GetComponent<BoardManager>();
            DontDestroyOnLoad(boardManager);
            return boardManager;
        }
    }
}
