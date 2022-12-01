using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManBehaviour : MonoBehaviour {

    private Animator an;

    void Start()
    {
        an = GetComponent<Animator>();
        an.SetBool("Walk", true);
    }
    // Use this for initialization
    void Update () {
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
