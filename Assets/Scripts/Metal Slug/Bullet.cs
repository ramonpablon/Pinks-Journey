using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5;
    public int damage = 1;
    public float destroyTime = 1.5f;


	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime); // destroi o projetil depois de um tempo
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D trigg)
    {
        Enemy otherEnemy = trigg.GetComponent<Enemy>();
        if(otherEnemy != null) //  se o projettil encontrar um corpo com a classe enemy, aplica damage
        {
            otherEnemy.TookDamage(damage);
        }
        if(gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
