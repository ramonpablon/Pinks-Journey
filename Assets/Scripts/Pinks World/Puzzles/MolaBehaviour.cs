using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolaBehaviour : MonoBehaviour {
    [Header("Var do impulso")]
    public float impulso;
    GameObject player; //var do player
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Rigidbody2D rbd = coll.rigidbody;
            // player.gameObject.SendMessage("JumpMove", impulso, SendMessageOptions.DontRequireReceiver);
            rbd.AddForce(transform.up * impulso, ForceMode2D.Impulse);
            anim.SetBool("active", true);
            anim.SetBool("active", false);
        }
    }
}
