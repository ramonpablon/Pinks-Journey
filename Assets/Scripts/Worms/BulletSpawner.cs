using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    [Header("Variaves")]
    public GameObject tiro;
    public GameObject tiroSpec;
    public float timer;
    bool canTiro;
	// Use this for initialization
	void Start () {
        StartCoroutine(Waiter());
        canTiro = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Waiter()
    {
        if (canTiro)
        {
            yield return new WaitForSeconds(timer);
            Instantiate(tiro, new Vector3(Random.Range(-6, 8), 6, -7), transform.rotation);
            yield return new WaitForSeconds(timer);
            Instantiate(tiro, new Vector3(Random.Range(-6, 8), 6, -7), transform.rotation);
            yield return new WaitForSeconds(timer);
            Instantiate(tiro, new Vector3(Random.Range(-6, 8), 6, -7), transform.rotation);
            yield return new WaitForSeconds(timer);
            Instantiate(tiro, new Vector3(Random.Range(-6, 8), 6, -7), transform.rotation);
            yield return new WaitForSeconds(timer);
            Instantiate(tiroSpec, new Vector3(Random.Range(-6, 8), transform.position.y, -7), transform.rotation);
            yield return new WaitForSeconds(timer); 
        }
        //StartCoroutine(Waiter());
        canTiro = false;
    }
    public void SetTimer(float newTime)
    {
        timer = newTime;
    }
    public void SetTiro(bool tiro)
    {

        canTiro = tiro;
        StartCoroutine(Waiter());
    }
}
