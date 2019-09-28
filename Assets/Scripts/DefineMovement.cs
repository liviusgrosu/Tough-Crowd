using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BPM 136
//136/60
public class DefineMovement : MonoBehaviour {
    //script that defines the movement of the player
    public float[] intervals;

    public GameObject masterSpawner;


    float bpm = 60.0f / 136.0f;
    float offset = 1.0f / 4.0f;

    bool onBeat;

    private int random;
    private int incr;


    public int[,] sequence;

    bool finished;


    // Use this for initialization
    void Start () {
        incr = 0;
        Random.InitState((int) Time.time);
        onBeat = false;

        finished = true;

        //0 - dont throw
        //1 - throw left
        //2 - throw right
        sequence = new int[,] {
            { 0, 1, 0, 2, 0, 1, 0, 2 },
            { 0, 0, 1, 1, 0, 0, 2, 2 },
            { 0, 1, 1, 1, 0, 2, 2, 2 },
            { 0, 1, 2, 1, 0, 2, 0, 1 },
            { 2, 0, 0, 2, 1, 0, 0, 1 },
            { 1, 1, 2, 1, 2, 2, 1, 2 },
            { 0, 2, 2, 0, 1, 0, 2, 0 },
            { 1, 0, 2, 1, 2, 0, 1, 2 },
            { 1, 1, 1, 1, 2, 2, 2, 2 } };

    }
	
	// Update is called once per frame
	void Update () {

        //print("time: " + Time.time + " | bpm: " + bpm + " | time % bpm: " + Time.time % bpm);


        if(finished == true)
        {
            finished = false;
            random = Random.Range(0,8);
            //print("choosen random: " + random);
            incr = 0;
        }

        if ((Time.time - offset) % bpm <= 0.1)
        {
            if (!onBeat)
            {
                onBeat = true;
                //print("choosen hand: " + sequence[random, incr]);
                if(sequence[random, incr] == 1)
                    masterSpawner.GetComponent<masterSpawner>().spawn(1);
                else if(sequence[random, incr] == 2)
                    masterSpawner.GetComponent<masterSpawner>().spawn(2);

                incr++;
                if(incr >= 8)
                {
                    finished = true;
                }
            }
        }
        else
        {
            onBeat = false;
        }
        
        //int i = 0;
        /*if (i < intervals.Length)
        {
            if (intervals[i] > Time.time)
            {
                print("interval[i]: " + intervals[i]); 
                float rand = Random.value;
                if (rand < 0.5)
                {
                    // code to make left key the safe zone
                }
                else
                {
                    // code to make right key the safe zone
                }
                i++;
            }
        }*/
	}
}
