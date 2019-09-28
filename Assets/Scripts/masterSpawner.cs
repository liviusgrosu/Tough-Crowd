using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterSpawner : MonoBehaviour {

    public GameObject spawnerL;
    public GameObject spawnerR;
    public GameObject player;

    public bool spawnTheGoat;

    // Use this for initialization
    void Start () {

        spawnTheGoat = false;
    }
	
	// Update is called once per frame
	void Update () {

       /* if (Input.GetKeyDown("left"))
            spawnerL.GetComponent<Spawner>().spawn();
        if (Input.GetKeyDown("right"))
            spawnerR.GetComponent<Spawner>().spawn();
       */
    }

    public void spawn(int i)
    {
        if (!spawnTheGoat)
        {
            if (i == 1)
            {
                spawnerL.GetComponent<Spawner>().spawn();
            }
            else
            {
                spawnerR.GetComponent<Spawner>().spawn();
            }
        }
        else
        {
            player.GetComponent<Player>().loseGame();
            if (i == 1)
            {
                spawnerL.GetComponent<Spawner>().spawnGoat();
            }
            else
            {
                spawnerR.GetComponent<Spawner>().spawnGoat();
            }
        }
    }

    public void changeGoatState(bool state)
    {
        spawnTheGoat = state;
    }
}
