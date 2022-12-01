using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscadaBehaviour : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
	}

    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            player.gameObject.SendMessage("PlayerLift", true, SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            player.gameObject.SendMessage("PlayerLift", true, SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            player.gameObject.SendMessage("PlayerLift", false, SendMessageOptions.DontRequireReceiver);
        }
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("EnemyLift", false, SendMessageOptions.DontRequireReceiver);
        }
    }
}
