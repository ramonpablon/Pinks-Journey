using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoxBehaviour : MonoBehaviour {
    [Header("Variavel da camera")]
    public GameObject gamera; //camera
    //Voids da unity
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //gamera.gameObject.SendMessage("MoveCamera", SendMessageOptions.DontRequireReceiver); //movimenta a camera que nem o mario
			gamera.gameObject.SendMessage("SetMoving",true, SendMessageOptions.DontRequireReceiver); //movimenta a camera que nem o mario
        }
    }
	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			//gamera.gameObject.SendMessage("MoveCamera", SendMessageOptions.DontRequireReceiver); //movimenta a camera que nem o mario
			gamera.gameObject.SendMessage("SetMoving",false, SendMessageOptions.DontRequireReceiver); //movimenta a camera que nem o mario
		}
	}
    //*************************
}
