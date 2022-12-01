using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject porta;
	// Use this for initialization
	void Start () {
        Instantiate(porta, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
        porta.SetActive(false);
    }
}
