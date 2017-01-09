using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    /* Account Information */
    public string screenName;

    public int deckCount; //Max deck size.
    public int maxHandSize; //Max hand size.
    public int energy; //Energy, the player's resources.
    public int maxEnergy;
    public List<GameObject> hand;
    public Deck deck;
    public List<GameObject> entities;
    public int score;

    private GameObject uiCanvas;
    private List<GameObject> handUISlots;

    //TODO: Add deck and hand variables.

    // Use this for initialization
    void Start () {
        score = 0;
        energy = 0;
        maxEnergy = 0;
        maxHandSize = 10;

        uiCanvas = (GameObject)GameObject.Instantiate(Resources.Load("HandUI"), this.transform);

        for(int i = 0; i < maxHandSize; i++)
        {
            handUISlots.Add(uiCanvas.transform.Find("CardSlot" + i).gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    // method to draw Card
    void DrawCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (hand.Count < maxHandSize)
            {
                hand.Add(GameObject.Instantiate(deck.Draw()));                
            }
        }
    }

    void DiscardCard()//int parameter
    {

    }

    void RevealHand()
    {
        //TODO: Reveals hand to everyone.
    }


}
