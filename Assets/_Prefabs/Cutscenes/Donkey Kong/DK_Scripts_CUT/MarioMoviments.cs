using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMoviments : DKIntroCutscene {

    public GameObject barril;
    protected void Update()
    {
        print(timer);
        timer += Time.deltaTime;
        if(timer >= 10f)
        {
            an.SetBool("MarioMoviments", true);
        }
        if(timer >= 16f)
        {
            DestroyImmediate(barril.gameObject, true);
        }
    }
}
