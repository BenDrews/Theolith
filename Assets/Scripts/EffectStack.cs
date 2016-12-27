using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EffectStack : MonoBehaviour
{
    private Stack<Effect> stack;

    public static EffectStack effectStack; //A static member of EffectStack that can be accessed by any other member in the code.

    // Use this for initialization
    void Awake()
    {
        stack = new Stack<Effect>();
    }

    public void AddEffect(Effect e)
    {
        stack.Push(e);
    }

    public void RemoveEffect(Effect e)
    {
        stack.Pop();
    }

    public void ResolveEffect(Effect e)
    {
        stack.Pop().Resolve();
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
