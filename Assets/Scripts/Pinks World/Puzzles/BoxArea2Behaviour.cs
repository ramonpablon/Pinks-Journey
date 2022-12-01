using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxArea2Behaviour : MonoBehaviour {
    [Header("Porta que vai abrir ao colocar a caixa no lugar")]
    public GameObject door; //Porta q ira sumir
    SpriteRenderer spr; 
	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>(); //pega o componente de SpriteRenderer para efeitos graficos
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Box")
		{ 
			Debug.Log ("IAJEIAJEIJEAIJ");
			door.gameObject.SetActive(true); //destroi a porta
            
            //Efeitos de imagem
            Color c = spr.color;
            c.r = 0;
            c.g = 1;
            c.b = 1;
            spr.color = c;
        }
    }
}
