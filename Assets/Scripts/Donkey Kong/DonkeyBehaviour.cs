using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyBehaviour : MonoBehaviour {

    public Animator animador;
    public GameObject barril;
    public GameObject barrilBaixo;
    public Transform spawnPoint;
    public Transform spawnPointDown;

    Rigidbody2D rb;

    
    float timer;
    public float launch;

    AudioSource donkeyKongAudioSource;

    int lançou;


    // Use this for initialization
    void Start () {
        PlayerPrefs.SetString("level", "dk");
        animador.SetBool("Atack", false);
        animador.SetBool("AtackDown", false);
        animador.SetBool("Idle", true);
        animador.SetBool("Rage", false);
        rb = barril.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        timer += Time.deltaTime;
        Lançar();



    }

    void Atack()
    {
        if (timer > launch)
        {
            Instantiate(barril, spawnPoint.position, spawnPoint.rotation);
            //rb.velocity = spawnPoint.transform.forward * 40;
            timer = 0f;
        }
    }

    void AtackDown()
    {
        if (timer > launch)
        {
            Instantiate(barrilBaixo, spawnPointDown.position, spawnPointDown.rotation);

            timer = 0f;
        }
    }

    void Lançar()
    {
        lançou = Random.Range(1, 11);

        if (lançou <= 3)
        {
            animador.SetBool("Atack", true);
            animador.SetBool("AtackDown", false);
            animador.SetBool("Idle", true);
            animador.SetBool("Rage", false);
        }
        else if (lançou <= 5 && lançou > 3)
        {
            animador.SetBool("Atack", false);
            animador.SetBool("AtackDown", true);
            animador.SetBool("Idle", true);
            animador.SetBool("Rage", false);
        }
        else
        {
            animador.SetBool("Atack", false);
            animador.SetBool("AtackDown", false);
            animador.SetBool("Idle", true);
            animador.SetBool("Rage", true);
        }
    }





    public IEnumerator GlobalWaitForSeconds(float i)
    {
        yield return new WaitForSeconds(i);
    }
}
