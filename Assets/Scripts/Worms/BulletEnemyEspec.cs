using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyEspec : MonoBehaviour {
    Vector2 direction;
    AudioSource ads;
    GameObject player;
    Rigidbody2D rbd;
    Animator anim;
    public float dano;
    public GameObject tiroSpecBg;
    SpriteRenderer spr;
   

    // Use this for initialization
    void Start()
    {
        ads = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rbd = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        //  direction = new Vector2(player.transform.position.x - transform.position.x,
        //                         player.transform.position.y - transform.position.y);

        //  transform.up = direction;
        transform.SetPositionAndRotation(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 180, 0));
        ///transform.Rotate(new Vector3(0, 0, 180));
        rbd.AddRelativeForce(new Vector2(0, 15), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
        FaceMouse();
    }

    void FaceMouse()
    {


        // rotaciona instantaneamente
        // transform.up = Vector3.Lerp(transform.up, direction, lerpTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            ads.PlayScheduled(1);
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.SendMessage("ApplyDamage", dano, SendMessageOptions.DontRequireReceiver);
            }
            Color c = spr.color;
            c.r = 1;
            c.g = 1;
            c.b = 1;
            spr.color = c;
            rbd.velocity = new Vector2(0, 0);
            rbd.gravityScale = 0;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("xploding", true);
            Destroy(gameObject, 0.58f);
        }
        if (collision.gameObject.tag == "Taco")
        {
            Rebatida();
            print("oi");
        }
    }
    void Rebatida()
    {
        rbd.velocity = new Vector2(0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        rbd.AddRelativeForce(new Vector2(0, 20), ForceMode2D.Impulse);
        
        StartCoroutine(Esperador());
    }
    IEnumerator Esperador()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(tiroSpecBg, new Vector3(0, 7.22f, 6), new Quaternion(0, 0, -180, 0));
    }
}
