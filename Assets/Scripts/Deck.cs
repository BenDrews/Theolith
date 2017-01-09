using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public Player owner;

    private List<GameObject> cards;

    public void Shuffle()
    {
        Random rng = new Random();
        for(int i = 0; i < cards.Count; i++)
        {
            Swap(i, Random.Range(0, cards.Count - 1));
        }
    }

    private void Swap(int i, int j)
    {
        GameObject temp = cards[i];
        cards[i] = cards[j];
        cards[j] = temp;
    }

    public GameObject Draw()
    {
        GameObject drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }
    
}
