using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxbehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Rigidbody2D rbd = coll.gameObject.GetComponent<Rigidbody2D>();
            float speed = rbd.velocity.y;
            if (rbd.velocity.y >= 10)
            {
                speed = 10;
                Debug.Log(speed);
            }
        }
    }
}
