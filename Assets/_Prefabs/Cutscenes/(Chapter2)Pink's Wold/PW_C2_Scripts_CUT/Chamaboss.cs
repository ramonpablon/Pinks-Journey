using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamaboss : MonoBehaviour {

    public GameObject boss;
    public GameObject other;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        boss.SetActive(true);
        other.SetActive(false);
        Destroy(gameObject);
    }
}
