using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Effect
{
    public int cost = 0;

    public virtual void Resolve()
    {
    }

    public virtual IEnumerator GetEnumerator() {
        yield return this;
    }
}
