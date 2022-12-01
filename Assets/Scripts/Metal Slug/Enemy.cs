using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public AudioSource ads;
    public int health;
    public float speed;
    public float attackDistance;

    public GameObject deathAnimation;
    public GameObject deathAnimation2;

    protected Animator an;
    protected bool facingRight = true;
    protected Transform target;
    protected float targetDistance;
    protected Rigidbody2D rb;

    protected SpriteRenderer sprite;


	void Awake () { // awake executa um instante antes de Start
        ads = GetComponent<AudioSource>();
        an = GetComponent<Animator>();
        target = FindObjectOfType<PlayerBehaviour>().transform;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	protected virtual void Update () {
        targetDistance = transform.position.x - target.position.x;
    } // protected virtual é um bizu pra não bugar e confundir com outros update de inimigos

    protected void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale; // scale recebe a escala do player

        scale.x *= -1; // inverte a posição atual do inimigo

        transform.localScale = scale;
    }

    public void TookDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //ads.PlayScheduled(Time.time);
            Destroy();

            Instantiate(deathAnimation, transform.position, transform.rotation); // spawna o objeto de morte
            Instantiate(deathAnimation2, transform.position, transform.rotation); // spawna o objeto de morte

        }
        else
            StartCoroutine(TookDamageCoRoutine()); // inicia corotina de cor
    } 

    IEnumerator TookDamageCoRoutine() 
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    } // corotina que muda a cor do inimigo para vermelho quando atingido

    public void Destroy()
    {
       // ads.PlayScheduled(1);
        Destroy(gameObject);
    }


}
