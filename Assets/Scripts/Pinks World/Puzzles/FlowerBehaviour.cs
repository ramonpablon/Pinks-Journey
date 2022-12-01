using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour {
    [Header("Variaveis")]
    public Animator anim;
    SpriteRenderer spr;
    public float tempParado;
    public GameObject meio;
    bool cangrow;
    public bool ativo;
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        spr = anim.gameObject.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Q)) && cangrow && ativo)
        {
            anim.gameObject.SetActive(true);
            anim.SetBool("growth", true);
            audioSource.Play();
            StartCoroutine(Esperar());
        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player" && ativo)
        {
            cangrow = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && ativo)
        {
            cangrow = false;
        }
    }
    //**********************************************************************
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(tempParado);
        anim.SetBool("growth", false);
        
    }
    public void SetAtivo()
    {
        Debug.Log("shamo");
        Color c = spr.color;
        c.r = 1;
        c.b = 1;
        c.g = 1;
        spr.color = c;
        ativo = true;
    }
 
}
