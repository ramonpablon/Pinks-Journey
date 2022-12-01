using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : MonoBehaviour {

    public GameObject missile;
    public GameObject tempWorm;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer = +Time.time;
        if (timer >= 8f && timer <=8.02f)
        {
            Instantiate(missile, tempWorm.transform.position, tempWorm.transform.rotation);
        }
        if(timer>= 14f)
        {
            Destroy(gameObject);
        }
    }
}
