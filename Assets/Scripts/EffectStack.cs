using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EffectStack : MonoBehaviour
{
    private List<Effect> stack;

    public static EffectStack effectStack; //A static member of EffectStack that can be accessed by any other member in the code.

    // Use this for initialization
    void Awake()
    {
        stack = new List<Effect>();
    }

    public void AddEffect(Effect e)
    {
        stack.Add(e);
    }

    public void RemoveEffect()
    {
        Debug.Assert(stack.Count > 0);
        stack.RemoveAt(stack.Count - 1);
    }

    public void RemoveEffect(Effect e)
    {
        Debug.Assert(stack.Count > 0);
        stack.Remove(e);
    }

    public void ResolveEffect()
    {
        Effect rootEffect = stack[stack.Count - 1];
        RemoveEffect();
        foreach(Effect e in rootEffect)
        {
            e.Resolve();
        }
    }
    
    public static EffectStack GetEffectStack()
    {
        if (effectStack)
        {
            return effectStack;
        }
        else
        {
            effectStack = new EffectStack();
            DontDestroyOnLoad(effectStack);
            return effectStack;
        }
    }
}
