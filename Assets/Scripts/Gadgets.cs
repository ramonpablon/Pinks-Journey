using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gadgets : MonoBehaviour {

    public GameObject desativador;
    public GameObject ativador;
    public GameObject gadGet;
    public PlayerBehaviour PB;

    AudioSource audiosource;
    public AudioClip Shotgun;
    public AudioClip jump;
    public AudioClip taco;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D trigg)
    {
        if (trigg.gameObject.CompareTag("Player"))
        {
            desativador.SetActive(false);
            gadGet.SetActive(true);
            ativador.SetActive(true);
            UpdateWeapon();
            Destroy(gameObject);
        }
    }

    private void UpdateWeapon()
    {
        if (gadGet.name.Equals("Shotgun")) // se o objeto adicionado for o shotgun o player podera atirar
        {
            audiosource.PlayOneShot(Shotgun, 0.5f);
            PB.canFire = true;
        }
        if (gadGet.name.Equals("Baseball")) // se o objeto adicionado for o shotgun o player podera esporretear
        {
            audiosource.PlayOneShot(taco, 0.5f);
            PB.canTaco= true;
        }
        if (gadGet.name.Equals("Jump")) // se o objeto adicionado for o shotgun o player podera pular
        {
            audiosource.PlayOneShot(jump, 2f);
            PB.canJump = true;
        }
    }
}
