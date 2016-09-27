using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance; //A static member of GameManager that can be accessed by any other member in the code.
    private BoardManager boardGen;

    // Use this for initialization
    void Awake () {
        // Make sure only one instance of GameManager exists.
        if (instance == null)
        {
            instance = this;
        }

        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        //TODO: Create an instance of Board Manager.

        InitGame();
	}

    void InitGame() {
        //TODO: Make Board Manager do something.
    }

    void Update()
    {

    }
	
	// Update is called once per frame
}
