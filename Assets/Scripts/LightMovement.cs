using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {
    private Transform t;
    
    public float timer;
    public bool shiftRight;

    public int timeOffset;
    public int speed;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time < timer && shiftRight)
        {
            t.Rotate(Vector3.right * Time.deltaTime * speed);
        }
        else if (Time.time < timer && !shiftRight)
        {
            t.Rotate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            timer += timeOffset;
            if (shiftRight) shiftRight = false;
            else shiftRight = true;
        }
    }

    void newShift()
    {
        
    }
}
