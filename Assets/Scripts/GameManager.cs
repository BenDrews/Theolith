using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager; //A static member of GameManager that can be accessed by any other member in the code.
    private BoardManager boardManager;
    private EffectStack effectStack;
    private int turnCount = 0;

    public List<GameObject> players;
    public List<GameObject> entities;
    public GameObject selected;

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
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        
        boardManager = BoardManager.GetBoardManager();
        effectStack = EffectStack.GetEffectStack();
        InitGame();
	}

    void InitGame() {
        players.Add((GameObject)Instantiate(Resources.Load("TestPlayer1")));
        players.Add((GameObject)Instantiate(Resources.Load("TestPlayer2")));
        
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
            GameObject gameManagerObj = new GameObject("GameManager");
            gameManager = gameManagerObj.AddComponent<GameManager>().GetComponent<GameManager>();
            DontDestroyOnLoad(gameManager);
            return gameManager;
        }
    }
}
