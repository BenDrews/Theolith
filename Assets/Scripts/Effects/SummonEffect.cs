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
        //Get the GameManager to invoke relevant events
        GameManager gameManager = GameManager.GetGameManager();
        gameManager.onEntityEnter.Invoke();

        //Create a new instance of the target prefab and make sure it's an entity
        GameObject instanceOnBoard = (GameObject)GameObject.Instantiate(target);
        Entity entity = instanceOnBoard.GetComponent<Entity>();
        Debug.Assert(entity != null);

        //Set entity's cast time fields
        entity.SetController(controller);
        entity.SetTurnPlayed(gameManager.GetTurnCount());

        //Add it to the relevant lists of entities
        gameManager.entities.Add(entity.gameObject);
        controller.entities.Add(entity.gameObject);

        BoardManager.GetBoardManager().AddEntity(instanceOnBoard, x, y);
        gameManager.afterEntityEnter.Invoke();
        Destroy(gameObject);
    }
}
