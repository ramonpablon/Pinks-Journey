using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : Enemy
{



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update(); // chamando a função base do script, como ele esta herdado de enemy

        if (Mathf.Abs(targetDistance) < attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); // pega a posição do player atual, e move o objeto em certa velocidade
        }

    }
}
