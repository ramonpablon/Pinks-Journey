using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
   // Rigidbody2D rbd;
    float forca;
    AudioSource ads;
    bool isFlying;
    Vector2 dir;
    Animator anim;
    int animcontroler;
    Rigidbody2D rbd;
    GameObject gmw;
    SpriteRenderer spr;
    void Start()
    {
        ads = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
        gmw = GameObject.FindGameObjectWithTag("GameController");
        animcontroler = Random.Range(1, 5);
        anim = GetComponent<Animator>();
        rbd = GetComponent<Rigidbody2D>();
        isFlying = true;
        transform.Rotate(new Vector3(0, 0, 0));
       // rbd.velocity = new Vector2(0, 0);  
        Destroy(gameObject, 3f);
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector2(0,0.1f));
        /*   dir = new Vector2(rbd.velocity.x, rbd.velocity.y);
           if (isFlying)
           {
               forca = Random.Range(0.4f, 5f);
               SetRotation(45, -45);
               rbd.AddRelativeForce(new Vector2(0, forca), ForceMode2D.Impulse);
               isFlying = false;
           }


           // Determinaçao do angulo do vetor velocidade
           dir.Normalize();
           float angle = Mathf.Asin(dir.y) * Mathf.Rad2Deg;
           if (dir.x < 0f)
           {
               angle = 180 - angle;
           }
       }
       private void OnTriggerEnter2D(Collider2D coll)
       {
           if (coll.gameObject.tag == "CenarioTag")
           {
               rbd.gravityScale = 0;
               rbd.velocity = new Vector2(0, 0);
               transform.localEulerAngles = new Vector3(0, 0, 0);
               transform.localScale = new Vector3(1.5f, 1.5f, 0);
               anim.SetInteger("bullet",animcontroler);
               Destroy(gameObject, 1f);
           }
       }
       public void SetSpeed(float speed)
       {
           forca = speed;
       }
       public void SetRotation(float min, float max)
       {
           transform.localEulerAngles = new Vector3(0, 0, Random.Range(min, max));
       }
       public void SetFlying()
       {
           isFlying = true;*/
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "CenarioTag")
        {
            ads.PlayScheduled(1);
            Color c = spr.color;
            c.r = 1;
            c.g = 1;
            c.b = 1;
            spr.color = c;
            gmw.gameObject.SendMessage("SetVida", 1, SendMessageOptions.DontRequireReceiver);
            rbd.gravityScale = 0;
            rbd.velocity = new Vector2(0, 0);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
            anim.SetInteger("bullet", animcontroler);
            Destroy(gameObject, 1f);
            rbd.gravityScale = 0;
            rbd.velocity = new Vector2(0, 0);
        }
    }
}
