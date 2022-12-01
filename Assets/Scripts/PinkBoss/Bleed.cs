using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour {
    public GameObject orb;
    public GameObject orbSpec;
    float contador;
	// Use this for initialization
	void Start () {
        StartCoroutine(Bleeding());
	}
	
	// Update is called once per frame
	IEnumerator Bleeding()
    {
        while (true)
        {
            if(contador % 5 == 0)
            {

                Instantiate(orbSpec, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(orb, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(2.5f);
            contador += 1.5f;
        }
    }
}
