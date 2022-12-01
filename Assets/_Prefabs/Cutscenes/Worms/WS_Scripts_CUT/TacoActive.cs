using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoActive : MonoBehaviour {

    public GameObject missile;

    public GameObject taco;

    public GameObject spawnPointCut;

    WormBehaviour wb;

    // Update is called once per frame
    void Update () {
        wb = GetComponent<WormBehaviour>();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1;
            gameObject.SendMessage("SetAtivo", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
		if(taco == null)
        {
            Instantiate(missile, spawnPointCut.transform.position, spawnPointCut.transform.rotation);
            Destroy(spawnPointCut.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D trigg)
    {
        if (trigg.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
        }
    }
}
