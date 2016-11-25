using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int deckCount; //Max deck size.
    public int maxHandSize; //Max hand size.
    public int energy; //Energy, the player's resources.
    //private Card[] hand;
    //private Deck deck;
    //TODO: Add deck and hand variables.

	// Use this for initialization
	void Start () {
	    //TODO: Initialize all variables.
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    // method to draw Card
    void drawCard()
    {
        //TODO: Interact with deck to get a card.
    }

    void discardCard()//int parameter
        //TODO: Discard a card from hand by removing a specific card in hand
    {

    }

    void revealHand()
    {
        //TODO: Reveals hand to everyone.
    }


}
