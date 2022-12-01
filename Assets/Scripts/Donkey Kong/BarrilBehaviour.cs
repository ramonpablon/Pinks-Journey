using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilBehaviour : MonoBehaviour {

    float destroyBarril;
    public bool fired= false;

    public int damage;

    public int newton;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        destroyBarril = GameObject.FindGameObjectWithTag("Destroy").transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(!fired)
        {
            rb.AddForce(transform.right * newton * Time.fixedDeltaTime, ForceMode2D.Impulse);
            fired = true;
        }
        Destruir();
    }

    void Fire()
    {
        fired = true;
    }

    void Destruir()
    {
        if (transform.position.y < destroyBarril) 
            Destroy(gameObject);
    }
}
