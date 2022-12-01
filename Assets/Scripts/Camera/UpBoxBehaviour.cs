using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBoxBehaviour : MonoBehaviour {
    [Header("Variavel da camera")]
    public GameObject gamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            gamera.gameObject.SendMessage("SetUping", true, SendMessageOptions.DontRequireReceiver);
        }
    }
}
