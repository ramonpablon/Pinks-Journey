using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxWorms : MonoBehaviour
{
    [Header("Basicamente a velocidade, deixei baixo para gráficos pequenos.")]
    public float speed;
    public bool isWater;
    Renderer mat;
    // Use this for initialization
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>();
        if (isWater)
        {
            StartCoroutine(Waiter());
        }
    }

    // Update is called once per frame
    void Update()
    {
       


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mat.material.mainTextureOffset = new Vector2(mat.material.mainTextureOffset.x + Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0);
        }

    }
    IEnumerator Waiter()
    {
        while (true)
        {
            
            transform.Translate(new Vector2(0,0.1f));
            yield return new WaitForSeconds(0.5f);
            transform.Translate(new Vector2(0, -0.1f));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
