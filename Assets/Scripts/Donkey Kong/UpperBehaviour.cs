using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBehaviour : MonoBehaviour {

    private GameObject escada;

    private void Start()
    {
        escada = GameObject.FindGameObjectWithTag("Escada");
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Escada")
        {
            escada.gameObject.SendMessage("EnemyLift", true, SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Escada")
        {
            escada.gameObject.SendMessage("EnemyLift", false, SendMessageOptions.DontRequireReceiver);
        }
    }

}
