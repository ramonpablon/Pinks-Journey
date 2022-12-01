using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpec : MonoBehaviour
{
    Transform player;
    Transform boss;
    Rigidbody2D rbd;
    bool going2player;
    float targetX;
    float targetY;
    float dirx;
    float diry;
    float speed;
    float scale;
    // Use this for initialization
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        dirx = Random.Range(-5, 5);
        diry = Random.Range(-5, 5);
        rbd.AddForce(new Vector2(dirx, diry), ForceMode2D.Impulse);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = 3;
        scale = 1;
        going2player = true;
        StartCoroutine(Goer());
        boss = GameObject.FindGameObjectWithTag("BossEye").transform;
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
            transform.position = Vector2.MoveTowards(transform.position, player.position, 2* Time.deltaTime);
        }
        if (!going2player)
        {
            transform.position = Vector2.MoveTowards(transform.position, boss.position, 6 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "BossEye")
        {

            collision.gameObject.SendMessage("DanoChefe", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Taco")
        {
            Rebatida();
        }
    }
    void Rebatida()
    {
        going2player = false;
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
