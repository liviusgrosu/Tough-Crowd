using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiance : MonoBehaviour {

    public bool isDown;
    public bool isUp;

    public bool goingDown;
    public bool goingUp;

    public float downSpeed;
    public float upSpeed;

    public float downTime;
    public float upTime;

    float pDownTime;
    float pUpTime;

    public float downLength;
    public float upLength;

    float pDownLength;
    float pUpLength;

    public bool begin;
    public bool jumping;

    // Use this for initialization
    void Start () {
        isUp = true;
        jumping = false;
        pDownLength = downLength;
        pUpLength = upLength;

        pDownTime = downTime;
        pUpTime = upTime;
    }
	
	// Update is called once per frame
	void Update () {
        //print("jumping: " + jumping);

        if(begin && !jumping)
        {
            jumping = true;
            //print("Jumping");
            gameObject.GetComponent<Rigidbody>().AddForce(0, upLength, 0, ForceMode.Impulse);
            begin = false;
            //print("moving"); 
            /*if (isDown && !goingDown && !isUp && !goingUp)
            {
                print("holding down");
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                downTime -= Time.deltaTime;
                if (downTime <= 0.0f)
                {
                    isDown = false;
                    goingUp = true;
                    downTime = pDownTime;
                }
            }
            if (!isDown && goingDown && !isUp && !goingUp)
            {
                print("going down");
                GetComponent<Rigidbody>().velocity = new Vector3(0, -downSpeed, 0);
                downLength -= Time.deltaTime * downSpeed;
                if (downLength <= 0.0f)
                {
                    isDown = true;
                    goingDown = false;
                    downLength = pDownLength;
                }
            }
            if (!isDown && !goingDown && isUp && !goingUp)
            {
                print("holding up");
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                upTime -= Time.deltaTime;
                if (upTime <= 0.0f)
                {
                    isUp = false;
                    goingDown = true;
                    upTime = pUpTime;
                }
            }
            if (!isDown && !goingDown && !isUp && goingUp)
            {
                print("going up");
                GetComponent<Rigidbody>().velocity = new Vector3(0, downSpeed, 0);
                upLength -= Time.deltaTime * upSpeed;
                if (upLength <= 0.0f)
                {
                    isUp = true;
                    goingUp = false;
                    upLength = pUpLength;
                    begin = false;
                }
            }*/
        }
    }
    public void move()
    {
        //begin = true;
        if (!jumping)
        {
            jumping = true;
            gameObject.GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            jumping = false;
        }
    }
}
