using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager; //A static member of GameManager that can be accessed by any other member in the code.
    private BoardManager boardGen;
    private int turnCount = 0;
    

    // Events
    public UnityEvent onTurnStart;
    public UnityEvent onTurnEnd;
    public UnityEvent onCombat;
    public UnityEvent afterCombat;
    public UnityEvent onDraw;
    public UnityEvent afterDraw;
    public UnityEvent onCardCast;
    public UnityEvent afterCardCast;
    public UnityEvent onEntityDamage;
    public UnityEvent afterEntityDamage;
    public UnityEvent onEntityHeal;
    public UnityEvent afterEntityHeal;
    public UnityEvent onEntityEnter;
    public UnityEvent afterEntityEnter;
    public UnityEvent onEntityLeave;
    public UnityEvent afterEntityLeave;
    public UnityEvent onCommand;
    public UnityEvent afterCommand;
    public UnityEvent onTileEntered;
    public UnityEvent onTileLeft;


    // Use this for initialization
    void Awake () {
        //TODO: Create an instance of Board Manager.
        boardGen = BoardManager.GetBoardManager();
        InitGame();
	}

    void InitGame() {

    }

    void Update()
    {

    }

    public int GetTurnCount()
    {
        return turnCount;
    }
	
    public static GameManager GetGameManager()
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
