using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCUbo : MonoBehaviour {
    float timer = 0;
    public GameObject box;
    BoxCollider2D bc;
	// Update is called once per frame
	void Update () {
        timer = +Time.time;
        bc = GetComponent<BoxCollider2D>();
        if (timer >= 14f)
        {
            bc.enabled = true;
        }
    }
}
