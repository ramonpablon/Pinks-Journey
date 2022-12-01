using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerMissile : Enemy
{

    public GameObject missile;
    public float fireRate;
    public Transform shotSpawner;
    private float nextFire;

    float timer;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetString("level", "ms");
        timer = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        if (timer > 6)
            timer = 0;
        if (targetDistance < 0)
        {
            if (facingRight)
                Flip();
        }
        else
        {
            if (!facingRight)
                Flip();
        }

        if (timer > 2 && timer < 2.3)
        {
            if (Mathf.Abs(targetDistance) < attackDistance && Time.time > nextFire)
            {
                an.SetTrigger("Shooting");
                nextFire = Time.time + fireRate;
            }

        }

    }

    public void Shooting()
    {
        GameObject tempBullet = Instantiate(missile, shotSpawner.position, missile.transform.rotation);
        if (!facingRight)
        {
            tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        an.SetBool("Reload", true);
    }
}
