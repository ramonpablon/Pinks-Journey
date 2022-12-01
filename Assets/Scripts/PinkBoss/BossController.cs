using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossController : MonoBehaviour {
    public SpriteRenderer spr;
    public int vida;
    AudioSource ads;
    
	// Use this for initialization
	void Start () {
        ads = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(vida == 0)
        {
            SceneManager.LoadScene(8);
        }
	}
    void DanoChefe()
    {
        ads.PlayScheduled(1);
        vida -= 1;
        StartCoroutine(DamageEffect());
    }
    IEnumerator DamageEffect()
    {
        Color c = spr.color;
        c.g = 0.75f;
        c.b = 0.50f;
        spr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 1f;
        c.b = 1f;
        spr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 0.75f;
        c.b = 0.50f;
        spr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 1f;
        c.b = 1f;
        spr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 0.75f;
        c.b = 0.50f;
        spr.color = c;
        yield return new WaitForSeconds(0.1f);
        c.g = 1f;
        c.b = 1f;
        spr.color = c;
    }
}
