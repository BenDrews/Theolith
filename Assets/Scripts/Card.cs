using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {

    public int cost;
    public GameObject effect;
    public string text;
	
    // Use this for initialization
	void Start () {

	}

    //Cast the spell
    void Cast()
    {   
        EffectStack.GetEffectStack().AddEffect(effect);   
    }
}
