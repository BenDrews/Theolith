using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* Class that used for interactable objects that occupy board space */
public class Entity : MonoBehaviour {

    public enum Type : byte { Structure, Minion, Carpet };

    public byte type;
    public string text;
    public bool canMove = true;
    public bool canAttack = true;
    public bool canBeAttacked = true;
    public int attack = 1;
    public int maxHealth = 1;
    public int health = 1;
    public int maxActions = 1;
    public int speed = 1;
    public int cost = 0;

    private int x = 0;
    private int y = 0;
    private int turnPlayed;
    private int actionsRemaining;
    private Player controller;
    //private ArrayList<Buff> buffs;

    private GameObject uiCanvas;
    private Text attackStatLabel;
    private Text healthStatLabel;

    // Use this for initialization
    void Start () {
        uiCanvas = (GameObject)GameObject.Instantiate(Resources.Load("BaseStatLabel"), this.transform);

        attackStatLabel = uiCanvas.transform.Find("AttackStat").gameObject.GetComponent<Text>();
        attackStatLabel.text = attack.ToString();

        healthStatLabel = uiCanvas.transform.Find("HealthStat").gameObject.GetComponent<Text>();
        healthStatLabel.text = health.ToString();
        turnPlayed = GameManager.GetGameManager().GetTurnCount();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetAttackStat(int atk)
    {
        attack = atk;
        attackStatLabel.text = attack.ToString();
    }

    int GetAttackStat()
    {
        return attack;
    }

    void SetHealthStat(int hp)
    {
        health = hp;
        healthStatLabel.text = health.ToString();
        if(hp <= 0)
        {
            Kill();
        }
    }

    int GetHealthStat()
    {
        return health;
    }

    int Damage(int dmg)
    {
        GameManager.GetGameManager().onEntityDamage.Invoke();
        SetHealthStat(health -= dmg);
        GameManager.GetGameManager().afterEntityDamage.Invoke();
        return health;
    }

    int Heal(int healing)
    {
        GameManager.GetGameManager().onEntityHeal.Invoke();
        SetHealthStat(health = Mathf.Min(health + healing, maxHealth));
        GameManager.GetGameManager().afterEntityHeal.Invoke();
        return health;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public void SetY(int y)
    {
        this.y = y;
    }

    public Player GetController()
    {
        return controller;
    }

    public void SetController(Player controller)
    {
        this.controller = controller;
    }

    public int GetTurnPlayed()
    {
        return turnPlayed;
    }

    public void SetTurnPlayed(int turn)
    {
        this.turnPlayed = turn;
    }

    public bool AttemptMove(int x, int y)
    {
        //TODO: Check conditions
        Move(x, y);
        return true;
    }

    public void Move(int newX, int newY)
    {
        GameManager gameManager = GameManager.GetGameManager();
        BoardManager boardManager = BoardManager.GetBoardManager();

        BoardTile oldTile = boardManager.GetTile(x, y).GetComponent<BoardTile>();
        BoardTile newTile = boardManager.GetTile(newX, newY).GetComponent<BoardTile>();
        gameManager.onTileLeft.Invoke();
        //TODO: Add animation to animation queue.
        oldTile.content = null;
        newTile.content = gameObject;
        x = newX;
        y = newY;
        transform.parent = newTile.transform;
        transform.position = newTile.transform.position;
        gameManager.onTileEntered.Invoke();
    }

    public bool AttemptFight(Entity opponent)
    {
        //TODO: Check conditions
        if(opponent != this && canAttack && opponent.canBeAttacked && controller != opponent.controller)
        {
            Fight(opponent);
            return true;
        } else
        {
            return false;
        }
        
    }

    public void Fight(Entity opponent)
    {
        //TODO: Add animation to queue
        //TODO: Check attack ranges (RangeModule component?) maybe needs a better name
        GameManager gameManager = GameManager.GetGameManager();
        gameManager.onEntityDamage.Invoke();
        gameManager.onEntityDamage.Invoke();

        SetHealthStat(health - opponent.GetAttackStat());
        opponent.SetHealthStat(opponent.GetHealthStat() - attack);

        gameManager.afterEntityDamage.Invoke();
        gameManager.afterEntityDamage.Invoke();
    }

    public void Kill()
    {
        GameManager gameManager = GameManager.GetGameManager();
        gameManager.onEntityLeave.Invoke();
        Destroy(gameObject);
        gameManager.afterEntityLeave.Invoke();
    }

    void OnMouseDown()
    {
        GameManager gameManager = GameManager.GetGameManager();
        BoardManager boardManger = BoardManager.GetBoardManager();
        if(gameManager.selected == null)
        {
            gameManager.selected = gameObject;
                        
        } else if(gameManager.selected.GetComponent<Entity>() != null)
        {
            gameManager.selected.GetComponent<Entity>().AttemptFight(this);
            gameManager.selected = null;
        }        
    }
}
