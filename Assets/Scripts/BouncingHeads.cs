using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingHeads : MonoBehaviour {

    private Transform t;

    public float timeOffset;
    public float moveSpeed = 0.5f;
    private float curTime;

	// Use this for initialization
	void Start () {
        curTime = Time.time;
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (curTime < Time.time)
        {
            curTime += timeOffset;
            moveSpeed = moveSpeed * -1;
        }
        t.Translate(0, moveSpeed, 0);
	}
}
