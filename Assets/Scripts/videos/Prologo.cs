using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Prologo : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        StartCoroutine(Waiter());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(53);
        SceneManager.LoadScene(1);
    }
}
