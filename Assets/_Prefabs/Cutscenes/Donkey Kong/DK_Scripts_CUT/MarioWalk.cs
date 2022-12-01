using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioWalk : DKIntroCutscene {

    public GameObject powerUp;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            an.SetBool("Walk", true);
        }
    }

    public void DropIten()
    {
        powerUp.SetActive(true);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
