using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKIntroCutscene : MonoBehaviour
{
    public float timer;

    protected Animator an;
    
    // Use this for initialization
    void Start()
    {
        an = GetComponent<Animator>();
    }

    public void Move()
    {
        gameObject.SendMessage("MarioMove");
    }
}
