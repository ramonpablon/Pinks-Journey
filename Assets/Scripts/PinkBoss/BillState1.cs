using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillState1 : MonoBehaviour {
    Rigidbody2D rbd;
    AudioSource ads;
    SpriteRenderer spr;
    int numeroMovimento;
    public Transform eyeshot;
    public GameObject eyebullet;
    public GameObject laser;
    Animator anim;
    Animator animFilho;
    int wichIdle;
    int wichlado;
    bool controler;
    bool atirando;
    int inicio;

	// Use this for initialization
	void Start () {
        ads = GetComponent<AudioSource>();
        PlayerPrefs.SetString("level", "bl");
        spr = GetComponent<SpriteRenderer>();
        animFilho = laser.GetComponent<Animator>();
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartAnim();
        controler = true;
        atirando = false;
        inicio = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (numeroMovimento > 0)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("stopped") && controler)
            {
                inicio++;
                wichIdle = Random.Range(1, 6);
                anim.SetInteger("idleselect", wichIdle);
                controler = false;
                StartCoroutine(WaiterAnim());
              
            }
        }
       
        if(numeroMovimento == 0 && controler )
        {

            anim.SetInteger("idleselect", 0);
            anim.SetInteger("goLado", wichlado);
            if(!AnimatorIsPlaying())
            {
                StartCoroutine(WaiterAtack());

                controler = false;
                atirando = false;
            }
           
        }
        if(controler == false && AnimatorIsPlaying("stopped")&& !atirando && inicio > 0) 
        {
            StartCoroutine(WaitSpawn());
        }
        
    }
    void StartAnim()
    {
        numeroMovimento = Random.Range(1, 4);
        wichlado = Random.Range(1, 5);
    }
    IEnumerator WaiterAnim()
    {
        yield return new WaitForSeconds(0.1f);
        numeroMovimento--;
        controler = true;
    }
    IEnumerator WaiterAtack()
    {
        ads.PlayScheduled(1);
        yield return new WaitForSeconds(1);
        laser.SetActive(true);
        animFilho.SetInteger("laserMovement", wichlado);
        yield return new WaitForSeconds(4.5f);
        laser.SetActive(false);
        numeroMovimento = Random.Range(1, 4);
        yield return new WaitForSeconds(2);
        anim.SetInteger("goLado", 0);
        wichlado = Random.Range(1, 5);

        
    }
    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    IEnumerator WaitSpawn()
    {
        atirando = true;
        yield return new WaitForSeconds(0.3f);
        Instantiate(eyebullet, eyeshot.position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(eyebullet, eyeshot.position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        controler = true; //retorna pro ciclo de idle->lado->ataque
    }
}

