using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

/* Class that holds the effects scheduled to be resolved */
public class EffectStack : MonoBehaviour
{
    private List<GameObject> stack;

    private static EffectStack effectStack; 

    /* Initialization */
    void Awake()
    {
        if(effectStack == null)
        {
            effectStack = this;
        }
        stack = new List<GameObject>();
    }

    /* Add a new effect object to the stack */
    public void AddEffect(GameObject effect)
    {
        Debug.Assert(effect.GetComponent<Effect>() != null);

        //Create the effect as a child of the stack
        stack.Add((GameObject)GameObject.Instantiate(effect, this.transform));
    }

    /* Remove the top effect object from the stack */
    public void RemoveEffect()
    {
        Debug.Assert(stack.Count > 0);
        stack.RemoveAt(stack.Count - 1);
    }

    /* Remove the referenced effect */
    public void RemoveEffect(GameObject effect)
    {
        Debug.Assert(stack.Count > 0);
        stack.Remove(effect);
    }

    /* Iterate through each atomic effect contained in the topmost effect and resolve them */
    public void ResolveEffect()
    {
        Effect rootEffect = stack[stack.Count - 1].GetComponent<Effect>();
        RemoveEffect();
        foreach(Effect e in rootEffect)
        {
            e.Resolve();
        }
    }
    
    /* Static method to access the singleton EffectStack */
    public static EffectStack GetEffectStack()
    {
        if (effectStack)
        {
            return effectStack;
        }
        else
        {
            GameObject effectStackObj = new GameObject("EffectStack");
            effectStack = effectStackObj.AddComponent<EffectStack>().GetComponent<EffectStack>();
            DontDestroyOnLoad(effectStack);
            return effectStack;
        }
    }
}
