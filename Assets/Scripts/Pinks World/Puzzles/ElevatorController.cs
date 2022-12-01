using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {
    [Header("Velocidade do elevador")]
    public float speed;
    bool subindo;
	// Use this for initialization
	void Start () {
        subindo = true;
	}
	// Update is called once per frame
	void Update () {
        if(subindo == false)
        {
            DescerElevator();
        }
        if(subindo == true)
        {
            SubirElevator();
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "ElevatorPoints")
        {
            subindo = !subindo;
        }
    }
    public void SubirElevator()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }
    public void DescerElevator()
    {
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));
    }


}
