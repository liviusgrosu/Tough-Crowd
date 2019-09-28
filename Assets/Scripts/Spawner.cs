using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject tomato;
    public GameObject goat;
	public GameObject player;
    public GameObject splatter;
    public GameObject masterSpawner;
    public GameObject scoreBoard;

    public float speed;
    public float delay;

    GameObject clone;

	// Use this for initialization
	void Start () {

    }

    public void spawn()
    {
        clone = Instantiate(tomato, transform.position, tomato.transform.rotation);
        clone.GetComponent<ballTest>().setSpawner(masterSpawner);
        clone.GetComponent<ballTest>().setScoreBoard(scoreBoard);
        clone.GetComponent<ballTest>().setSpeed(speed);
        clone.GetComponent<ballTest>().setDelay(delay);
        clone.GetComponent<ballTest>().getTarget(player);
        clone.GetComponent<ballTest>().setSplatter(splatter);
    }

    public void spawnGoat()
    {
        clone = Instantiate(goat, transform.position, goat.transform.rotation);
        clone.GetComponent<ballTest>().setSpeed(speed);
        clone.GetComponent<ballTest>().setDelay(delay);
        clone.GetComponent<ballTest>().getTarget(player);
        clone.GetComponent<ballTest>().setSplatter(splatter);
    }
}
