using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Transform t;
    private Animator anim;
    public GameObject[] audience;

    public bool lost;

    public int marginOfError;
    private int keyDownCount = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        t = GetComponent<Transform>();
        lost = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!lost)
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetButton("Left X")) && keyDownCount < marginOfError)
            {
                anim.SetInteger("state", -1);
                keyDownCount++;
                moveAudience();
            }
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetButton("Right B")) && keyDownCount < marginOfError)
            {
                anim.SetInteger("state", 1);
                keyDownCount++;
                moveAudience();
            }
            else
            {
                anim.SetInteger("state", 0);
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) keyDownCount = 0;
        }
        else
        {
            SceneManager.LoadScene("loseScreen");
            if (Input.GetButton("Reset"))
            {
                print("reseting");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void moveAudience()
    {
        foreach (GameObject member in audience)
        {
            member.GetComponent<Audiance>().move();
        }
    }
    public void loseGame()
    {
        lost = true;
    }
}
