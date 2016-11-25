using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager; //A static member of GameManager that can be accessed by any other member in the code.
    private BoardManager boardGen;

    // Use this for initialization
    void Awake () {
        //TODO: Create an instance of Board Manager.
        //boardGen = BoardManager.getBoardManager();
        InitGame();
	}

    void InitGame() {
    }

    void Update()
    {

    }
	
    public static GameManager getGameManager()
    {
        if (gameManager)
        {
            return gameManager;
        }
        else
        {
            gameManager = new GameManager();
            DontDestroyOnLoad(gameManager);
            return gameManager;
        }
    }
}
