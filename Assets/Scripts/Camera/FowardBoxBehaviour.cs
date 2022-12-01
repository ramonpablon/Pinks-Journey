using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardBoxBehaviour : MonoBehaviour {
    [Header("Variavel da camera")]
    public GameObject gamera; //var da camera
	//Voids da Unity
	void Start () {
		
	}
	void Update () {
		
	}
    public void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
			gamera.gameObject.SendMessage("SetMoving",true, SendMessageOptions.DontRequireReceiver); //efeito da camera movimentando que nem Mario
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
    //*****************************

}
