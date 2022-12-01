using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarrilBehaviour : MonoBehaviour {

    public GameObject fireMan;
    public GameObject oilBarril;

    public void OnTriggerEnter2D(Collider2D trigg)
    {
        if (trigg.gameObject.tag.Equals("OilBarril"))
        {
            Instantiate(fireMan, oilBarril.transform.position, oilBarril.transform.rotation);
            Destroy(gameObject);
        }
    }
}
