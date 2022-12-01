using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    [Header("Distancia do Player")]
    public float shuffleDistance; // mesma coisa que walkDistance
    private float somersault; // variavel que deside o tipo de ataque

    private bool shuffle;
    private bool walk;
    private bool somersaultBack;
    private bool somersaultFront;

    private bool attack = false;
    private bool slash = false;
    private bool random = false;

    [Header("Impulso de pulo")]
    public int newton;
    public GameObject somersaultPoint;

    private bool onGround = false;
    private Transform groundCheck;

    // Use this for initialization
    void Start()
    {
        groundCheck = gameObject.transform.Find("EnemyGroundCheck");
    }

    // Update is called once per frame
    protected override void Update() // sobrepõe o update do enemy.pai
    {
        base.Update();
        an.SetBool("OnGround", onGround);
        an.SetBool("Shuffle", shuffle);
        an.SetBool("Walk", walk);

        an.SetBool("Attack", attack);
        an.SetBool("Slash", slash);

        an.SetBool("SomersaultFront", somersaultFront);
        an.SetBool("SomersaultBack", somersaultBack);

        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); // se a linha do enemy ate o groundCheck estiver tocando na camada de nome "Ground"

        if (Mathf.Abs(targetDistance) < shuffleDistance) // em uma certa distancia do player o enemy prepara para correr
        {
            shuffle = true;
        }

        if (Mathf.Abs(targetDistance) < attackDistance) // em uma certa distancia do player o inimigo começa a atacar
        {
            Attacking(); 
        }
    }

    private void FixedUpdate()
    {
        if (walk && !somersaultFront && !somersaultBack && !attack) // se enemy não estiver atacando ele anda e vira na direção do player
        {
            if (targetDistance < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);

                if (facingRight)
                    Flip();
            } // right direction

            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (!facingRight)
                {
                    Flip();
                }
            } // lefth direction
        }

        if (onGround)
        {
            somersaultBack = somersaultFront = false;
        }

        Somersault();
    }

    private void Attacking()
    {
        if (random)
        {
            somersault = Random.Range(1, 301);
            random = false;
        }

        else if (somersault > 0) 
        {
            if (somersault < 100) // da uma cambalhota para tras e um slash
            {
                somersaultBack = true;
                somersault = 0;
            }
            if (somersault < 200 && somersault > 100) // da uma cambalhota para frente e um ataque
            {
                somersaultFront = true;
                somersault = 0;
            }
        }

        else if (somersault > 200) // ataca o player sem cambalhota
        {
            attack = true;
            somersault = 0;
        }
    }

    private void Somersault() // função de impulso do pulo
    {
        if (somersaultBack)
        {
            rb.AddForce(somersaultPoint.transform.right * newton * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        if(somersaultFront)
        {
            rb.AddForce(somersaultPoint.transform.up * newton * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    public void ResetAttack() // chamamos esta função no animation para evitar bugs
    {
        attack = false;
        slash = false;
    }

    public void Walking() // chamamos esta função no animation para evitar bugs
    {
        walk = true;
        shuffle = false;
    }

    public void Randomized() // chamamos essa função no animation para setar um tempo entre um ataque e outro
    {
        random = true;
    }


    public void Slider()
    {
        slash = true;
    } 

    public void Attaker()
    {
        attack = true;
    }
}
