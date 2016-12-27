using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public enum Type : byte { Structure, Minion, Carpet };

    public byte type;

    private int attack;
    private int health;
    private int cost;
    private int turnPlayed;
    private int maxActions;
    private int actionsRemaining;
    private bool canMove;
    private bool canAttack;
    private Player controller;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetAttackStat(int atk)
    {
        attack = atk;
    }

    int GetAttackStat()
    {
        return attack;
    }

    void SetHealthStat(int hp)
    {
        health = hp;
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

    void EnterBoard()
    {

    }

    void leaveBoard()
    {

    }
}
