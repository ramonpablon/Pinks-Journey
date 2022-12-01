using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuvemBehaviour : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Time.deltaTime * speed, 0));

    }
    void SetSpeed(float novaspeed)
    {
        speed = novaspeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "NuvemDeath")
        {
            Destroy(gameObject);
        }
    }

}
