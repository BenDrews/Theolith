using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SummonEffect : Effect
{

    public GameObject target;
    public int x;
    public int y;

    public override void Resolve()
    {
        GameManager gameManager = GameManager.GetGameManager();
        gameManager.onEntityEnter.Invoke();
        BoardManager.GetBoardManager().AddEntity(target, x, y);
        gameManager.afterEntityEnter.Invoke();
    }
}
