using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {
    Transform player;
    Rigidbody2D rbd;
    bool going2player;
    float targetX;
    float targetY;
    float dirx;
    float diry;
    float speed;
    float scale;
    // Use this for initialization
    void Start () {
        rbd = GetComponent<Rigidbody2D>();
        dirx = Random.Range(-5, 5);
        diry = Random.Range(-5, 5);
        rbd.AddForce(new Vector2(dirx, diry), ForceMode2D.Impulse);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = 1;
        scale = 1;
        going2player = false;
        StartCoroutine(Goer());
	}
    private void Awake()
    {
        StartCoroutine(DeadByLifetime());
    }
    private void FixedUpdate()
    {
        transform.localScale = new Vector2(scale, scale);
        if (going2player)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    IEnumerator Goer()
    {
        yield return new WaitForSeconds(2);
        targetX = player.position.x;
        targetY = player.position.y;
        going2player = true;
    }
    IEnumerator DeadByLifetime()
    {
        
        yield return new WaitForSeconds(2);
        Destroy(gameObject, 7f);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            
            speed -= (speed > 0) ? 0.1f : 0;
            scale -= 0.01f;
        }
    }
}
