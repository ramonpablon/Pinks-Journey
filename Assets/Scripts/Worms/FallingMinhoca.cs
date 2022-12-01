using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMinhoca : MonoBehaviour
{
    Rigidbody2D rbd;
    float rot;
    // Use this for initialization
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        rot = Random.Range(0.3f, 8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rot);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject, 4f);
            rbd.velocity = new Vector2(0, 0);
            rbd.gravityScale = 3;
        }
    }
}
