using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour {

    public float a;

    public float screenWidth;

    public float screenHeigth;

    // Use this for initialization
    void Start () {
        a = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        screenHeigth = Screen.width;
        screenHeigth = Screen.height;
        transform.localScale = new Vector3((a * screenWidth / screenHeigth), transform.localScale.y, transform.localScale.z); // a escala do objeto é multiplicada pela largura e algura (proporção)
	}
}
