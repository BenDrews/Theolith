using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {

    private int cost;
    private Sprite card; //Card's image.
    private List<Effect> effects;
    //private Text
    // private Minion minion; -Associated minion.
	// Use this for initialization
	void Start () {

	}

    //Cast the spell
    void Cast()
    {
        foreach(Effect e in effects)
        {
            EffectStack.GetEffectStack().AddEffect(e);
        }
    }
}
