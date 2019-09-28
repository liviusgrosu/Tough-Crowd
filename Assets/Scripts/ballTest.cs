using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballTest : MonoBehaviour {

    public GameObject target;
    public GameObject splatter;
    public GameObject spawner;
    public GameObject scorer;
    bool off_note;
    float angle = 30;
    float init_dist;

    public float speed;
    public float delay;


    bool goatTime;
    bool halt;
    public float halt_time;

	// Use this for initialization
	void Start () {
        goatTime = false;
        off_note = false;
        halt = false;
        init_dist = Vector3.Distance(transform.position, target.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        getPath(target.transform, transform);
	}

    void getPath(Transform end, Transform clone)
    {
        if (!halt)
        {
            // source and target positions
            Vector3 pos = transform.position;
            Vector3 target = end.position;

            // distance between target and source
            float dist = Vector3.Distance(pos, target);

            if (dist <= (init_dist / 2) && halt_time > 0.0f)
            {
                halt = true;
                return;
            }

            // rotate the object to face the target
            transform.LookAt(target);

            // calculate initival velocity required to land the cube on target using the formula (9)
            float Vi = Mathf.Sqrt(dist * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * angle * 2)));
            float Vy, Vz;   // y,z components of the initial velocity

            Vy = Vi * Mathf.Sin(Mathf.Deg2Rad * angle);
            Vz = Vi * Mathf.Cos(Mathf.Deg2Rad * angle);

            // create the velocity vector in local space
            Vector3 localVelocity = new Vector3(0f, Vy, Vz);

            // transform it to global vector
            Vector3 globalVelocity = transform.TransformVector(localVelocity);

            // launch the cube by setting its initial velocity
            GetComponent<Rigidbody>().velocity = globalVelocity * speed;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            //print("halting");
            halt_time -= (Time.deltaTime * delay);
            if (halt_time <= 0.0f)
                halt = false;
        }
    }

    public void getTarget(GameObject player)
    {
        target = player;
    }

    void OnCollisionEnter(Collision collision)
    {
        //print("collision: " + collision.gameObject.name);
        if (collision.gameObject.name == "newPlayerCollider")
        {
            spawner.GetComponent<masterSpawner>().changeGoatState(true);
            print("you got hit");

            Destroy(gameObject);
        }
        if(collision.gameObject.name == "stage" || collision.gameObject.name == "splatter")
        {
            //print("hit the stage");
            scorer.GetComponent<ScoreManager>().increment();
            Instantiate(splatter, transform.position, splatter.transform.rotation);
            Destroy(gameObject);
        }
    }

    public void setSpeed(float val)
    {
        speed = val;
    }

    public void setDelay(float val)
    {
        delay = val;
    }

    public void setSplatter(GameObject obj)
    {
        splatter = obj;
    }

    public void setSpawner(GameObject obj)
    {
        spawner = obj;
    }
    public void setScoreBoard(GameObject obj)
    {
        scorer = obj;
    }
}
