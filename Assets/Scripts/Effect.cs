using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Effect : MonoBehaviour
{
    public delegate void ResolveDelegate();
    private ResolveDelegate effectFunction;
    private int cost;
    
    public Effect(ResolveDelegate effectFunction, int cost) {
        this.effectFunction = effectFunction;
        this.cost = cost;
    }

    public void Resolve()
    {
        effectFunction();
    }
}
