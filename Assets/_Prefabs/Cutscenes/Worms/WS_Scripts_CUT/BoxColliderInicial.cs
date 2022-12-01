using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderInicial : MonoBehaviour {

    float timer = 0;
    BoxCollider2D bc;
    // Update is called once per frame
    void Update()
    {
        timer = +Time.time;
        bc = GetComponent<BoxCollider2D>();
        if (timer >= 1f)
        {
            bc.enabled = false;
        }
    }
}
