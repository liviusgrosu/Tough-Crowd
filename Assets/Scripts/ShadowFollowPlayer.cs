using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFollowPlayer : MonoBehaviour {
    private Transform t;
    private Animator anim;
    private Vector3 pos;

    public float offset;

    public GameObject player;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
        pos = t.position;
        anim = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("playerDodgeLeft")) t.Translate(-1 * offset, 0, 0);
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("playerDodgeRight")) t.Translate(offset, 0, 0);
        else t.position = pos;
    }
}
