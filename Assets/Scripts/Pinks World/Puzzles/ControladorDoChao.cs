using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDoChao : MonoBehaviour {
    public GameObject chao1;
    public GameObject chao2;
    public GameObject chao3;
    bool ativo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ativo)
        {
            chao1.SetActive(true);
            chao2.SetActive(true);
            chao3.SetActive(true);
        }
	}
    void SetAtivo()
    {
        ativo = true;
    }
}
