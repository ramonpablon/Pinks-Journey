using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleBehaviour : MonoBehaviour {
    SpriteRenderer spr;
    SpriteRenderer spr_jr;
    public GameObject bleed;
    public int vida;
	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        spr_jr = GetComponentInChildren<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(vida == 0)
        {
            bleed.SetActive(true);
            Destroy(gameObject, 0.01f);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {

            TookDamage();
        }
    }
    void TookDamage()
    {
        vida -= 1;
        StartCoroutine(DamageEffect());

    }
    IEnumerator DamageEffect()
    {
        Color c = spr.color;
        c.g = 0.75f;
        c.b = 0.50f;
        spr.color = c;
        spr_jr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 1f;
        c.b = 1f;
        spr.color = c;
        spr_jr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 0.75f;
        c.b = 0.50f;
        spr.color = c;
        spr_jr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 1f;
        c.b = 1f;
        spr.color = c;
        spr_jr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 0.75f;
        c.b = 0.50f;
        spr.color = c;
        spr_jr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 1f;
        c.b = 1f;
        spr.color = c;
        spr_jr.color = c;
    }
}
