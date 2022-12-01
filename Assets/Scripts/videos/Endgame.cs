using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Endgame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Waiter());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(11);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
