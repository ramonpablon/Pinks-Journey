using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviourGameOver : MonoBehaviour
{
    public float speed;
    SpriteRenderer spr;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0));
        spr.flipX = (Input.GetAxisRaw("Horizontal") == 1) ? false : true;

    }
}
