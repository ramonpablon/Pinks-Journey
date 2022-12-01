using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehaviour : MonoBehaviour
{
    AudioSource ads;
    public AudioClip select;
    public AudioClip fire;
    int stateControler; //1=andando 0=parado
    int animControler;
    [Header("Var publicas")]
    public GameObject bullet;
    public Transform arma;
    public bool ativo = false;
    public Animator animSeta;
    Animator animMinhoca;
    float force;
    public GameObject proximaMinhoca;
    GameObject bulletSpawn;
    public GameObject tiroespecial;
    int randomAnim;
    bool taunting;
    static bool death;
    int i = 0;
    // Use this for initialization
    void Start()
    {
        ads = gameObject.GetComponent<AudioSource>();
        bulletSpawn = GameObject.FindGameObjectWithTag("BulletSpawner");
        animMinhoca = gameObject.GetComponent<Animator>();
        StartCoroutine(Contador());
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ativo && taunting && death == false)
        {
            randomAnim = Random.Range(0, 100);

            if(randomAnim > 80)
            {
                animMinhoca.SetBool("taunting", true);
                //animMinhoca.SetBool("taunting", false);
                taunting = false;
                
            }
            taunting = false;
        }
        if (ativo)
        {
            animMinhoca.SetBool("taunting", false);
            taunting = false;
            
        }
        if (death)
        {
            Rigidbody2D rbd = GetComponent<Rigidbody2D>();
            rbd.bodyType = RigidbodyType2D.Dynamic;
            rbd.gravityScale = 2;
            
            if (i == 0)
            {
                rbd.AddForce(new Vector2(0,0.3f), ForceMode2D.Impulse);
                i += 1;
            }
            animMinhoca.SetBool("taunting", true);
            Destroy(gameObject, 1f);
            
        }
    }
    IEnumerator Contador()
    {
        if (ativo && death == false)
        {
              animSeta.gameObject.SetActive(true);
              ads.clip = select;
              ads.PlayScheduled(1);
              yield return new WaitForSeconds(2.5f);
              animMinhoca.SetBool("firing", true);
              ads.clip = fire;
              ads.PlayScheduled(1);
              GameObject tiro = (GameObject)Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
              yield return new WaitForSeconds(1);
              ads.PlayScheduled(1);
              bulletSpawn.SendMessage("SetTiro", true, SendMessageOptions.DontRequireReceiver);
              animMinhoca.SetBool("firing", true);
              GameObject tiro2 = (GameObject)Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
              yield return new WaitForSeconds(1);
              ads.PlayScheduled(1);
              animMinhoca.SetBool("firing", true);
              GameObject tiro3 = (GameObject)Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
              yield return new WaitForSeconds(1);
              ads.PlayScheduled(1);
              animMinhoca.SetBool("firing", true);
              GameObject tiro4 = (GameObject)Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
              yield return new WaitForSeconds(1);
              ads.PlayScheduled(1);
              animMinhoca.SetBool("firing", true);
              GameObject tiroEspec = (GameObject)Instantiate(tiroespecial, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);

            yield return new WaitForSeconds(1);
              animMinhoca.SetBool("firing", false);
              proximaMinhoca.gameObject.SendMessage("SetAtivo", SendMessageOptions.DontRequireReceiver);
              ativo = false;
            taunting = true;
        }
        if (!ativo && death == false)
        {
            // animMinhoca.SetBool("idle", true);
            animSeta.gameObject.SetActive(false);
        }

    }
    public void SetAtivo()
    {
        ativo = true;
        if (ativo)
        {
            StartCoroutine(Contador());
        }
    }
    public static void SetDeath()
    {
        death = true;
    }
}
