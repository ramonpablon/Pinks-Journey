using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuvemSpawner : MonoBehaviour {
    float speedController;
    public bool direction;
    public GameObject nuvem1;
    public GameObject nuvem2;
    public float timer;
    bool canSpawn;
    int nuvemTipo;
	// Use this for initialization
	void Start () {
        nuvemTipo = Random.Range(0, 2);
        speedController = Random.Range(0.5f, 1f);
        timer = Random.Range(1, 10);
        canSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction)
        {
            if (canSpawn)
            {
                if (nuvemTipo == 0)
                {
                    GameObject novem = (GameObject)Instantiate(nuvem1, transform.position, transform.rotation);
                    canSpawn = false;
                    novem.gameObject.SendMessage("SetSpeed", speedController, SendMessageOptions.DontRequireReceiver);
                    StartCoroutine(Timer());
                }
                if (nuvemTipo == 1)
                {
                    GameObject novem = (GameObject)Instantiate(nuvem2, transform.position, transform.rotation);
                    canSpawn = false;
                    novem.gameObject.SendMessage("SetSpeed", speedController, SendMessageOptions.DontRequireReceiver);
                    StartCoroutine(Timer());
                }

            }
        }
        else
        {
            if (canSpawn)
            {
                if (nuvemTipo == 0)
                {
                    GameObject novem = (GameObject)Instantiate(nuvem1, transform.position, transform.rotation);
                    canSpawn = false;
                    novem.gameObject.SendMessage("SetSpeed", -speedController, SendMessageOptions.DontRequireReceiver);
                    StartCoroutine(Timer());
                }
                if (nuvemTipo == 1)
                {
                    GameObject novem = (GameObject)Instantiate(nuvem2, transform.position, transform.rotation);
                    canSpawn = false;
                    novem.gameObject.SendMessage("SetSpeed", -speedController, SendMessageOptions.DontRequireReceiver);
                    StartCoroutine(Timer());
                }

            }
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        timer = Random.Range(1, 10);
        speedController = Random.Range(0.5f, 1f);
        canSpawn = true;
    }
}
