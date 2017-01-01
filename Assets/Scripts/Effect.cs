using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Effect : MonoBehaviour
{
    public int cost = 0;
    public Player controller;

    public virtual void Resolve()
    {
        Destroy(gameObject);
    }

    public virtual IEnumerator GetEnumerator() {
        yield return this;
    }
}
