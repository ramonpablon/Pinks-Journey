using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAreaBehaviour : MonoBehaviour {
    [Header("Porta que vai abrir ao colocar a caixa no lugar")]
    public GameObject pengui; //Porta q ira sumir

    SpriteRenderer spr; 
	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>(); //pega o componente de SpriteRenderer para efeitos graficos
        PlayerPrefs.SetString("level", "pk");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Box")
        {
            pengui.SendMessage("SetAtivo", SendMessageOptions.DontRequireReceiver);            
            //Efeitos de imagem
            Color c = spr.color;
            c.r = 0;
            c.g = 0;
            c.b = 1;
            spr.color = c;
            BoxCollider2D bx = coll.gameObject.GetComponent<BoxCollider2D>();
            bx.enabled = false;
            Rigidbody2D collrgb = coll.gameObject.GetComponent<Rigidbody2D>();
            collrgb.gravityScale = 0;
            collrgb.velocity = new Vector2(0, 0);
            
        }
    }
}
