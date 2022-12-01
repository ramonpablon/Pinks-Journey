using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D trigg)
    {
        Debug.Log("Acertou");
        Enemy otherEnemy = trigg.GetComponent<Enemy>();
        if (otherEnemy != null) //  se o projettil encontrar um corpo com a classe enemy, aplica damage
        {
            otherEnemy.TookDamage(1);
        }
        if (gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
