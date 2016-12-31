using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Entity : MonoBehaviour {

    public enum Type : byte { Structure, Minion, Carpet };

    public byte type;
    public string text;
    public bool canMove = true;
    public bool canAttack = true;
    public int attack = 1;
    public int health = 1;
    public int maxActions = 2;
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
        healthStatLabel = uiCanvas.transform.Find("HealthStat").gameObject.GetComponent<Text>();
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
    }

    int GetHealthStat()
    {
        return health;
    }

    int Damage(int dmg)
    {
        GameManager.GetGameManager().onEntityDamage.Invoke();
        health -= dmg;
        GameManager.GetGameManager().afterEntityDamage.Invoke();
        return health;
    }

    int Heal(int healing)
    {
        GameManager.GetGameManager().onEntityHeal.Invoke();
        health += healing;
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

    public void Move(int x, int y)
    {

    }

    /* Use this method to add on cast effects as well as listeners for triggered effects */
    public virtual void onEnter()
    {

    }

    /* Use this methhod to add persistent effects */
    public virtual void afterEnter()
    {

    }
}
