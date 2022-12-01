using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy {

    [Header("Distancia do Player")]
    public float wallkDistance; //distancia de detecção do player
    AudioSource ads;
    private bool walk;
    private bool attack = false;

    // Update is called once per frame
    protected override void Update () {
        
        base.Update();
        an.SetBool("Walk", walk);
        an.SetBool("Attack", attack);


        if(Mathf.Abs(targetDistance) < wallkDistance) // em uma certa distancia do player o enemy comça a correr
        {
            walk = true;
        }
        if (Mathf.Abs(targetDistance) < attackDistance) // em uma certa distancia do player o inimigo começa a atacar
        {
            attack = true;
            walk = false;
        }
    }


    private void FixedUpdate()
    {
        if(walk && !attack)
        {
            if(targetDistance < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);

                if(facingRight)
                    Flip();
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if(!facingRight)
                {
                    Flip();
                }
            }
        }
    }

    public void ResetAttack() // chamamos esta função no animation para evitar bugs
    {
        attack = false;
    }
}
