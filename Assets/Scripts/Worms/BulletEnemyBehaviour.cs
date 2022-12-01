using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyBehaviour : MonoBehaviour {
    Vector2 direction;
    AudioSource ads;
    GameObject player;
    Rigidbody2D rbd;
    Animator anim;
    public float dano;

    // Use this for initialization
    void Start()
    {
        ads = GetComponent<AudioSource>();
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground" )
        {
            ads.PlayScheduled(1);
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.SendMessage("ApplyDamage", dano, SendMessageOptions.DontRequireReceiver);
            }
            rbd.velocity = new Vector2(0, 0);
            rbd.gravityScale = 0;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("xploding", true);
            Destroy(gameObject, 0.58f);
        }
    }

}
