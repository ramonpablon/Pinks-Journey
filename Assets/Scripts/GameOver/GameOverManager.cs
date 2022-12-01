using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    public GameObject bgwmr;
    public GameObject bgms;
    public GameObject bgdk;
    public GameObject bgpk;
    public GameObject bgbl;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetString("level") == "ms")
        {
            bgms.SetActive(true);
        }
        if (PlayerPrefs.GetString("level") == "pk")
        {
            bgpk.SetActive(true);
        }
        if (PlayerPrefs.GetString("level") == "wr")
        {
            bgwmr.SetActive(true);
        }
        if (PlayerPrefs.GetString("level") == "dk")
        {
            bgdk.SetActive(true);
        }
        if (PlayerPrefs.GetString("level") == "bl")
        {
            bgbl.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
