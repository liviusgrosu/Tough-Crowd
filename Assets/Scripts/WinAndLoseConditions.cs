using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndLoseConditions : MonoBehaviour {
    private bool lost = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!lost && Time.time > 120)
        {
            // Todo: enter code to show winning UI
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "tomato")
        {
            // Todo: enter code to show losing UI
            lost = true; // this is needed to indicate the game is ready to be reset
            Time.timeScale = 0; // this pauses the game
        }
    }
}
