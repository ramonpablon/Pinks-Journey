using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Enemy {

    public GameObject bulletPrefab;
    public float fireRate;
    private float nextFire;

    float timer=0;

    public Transform shotSpawner;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        timer += Time.deltaTime;
        if (timer > 6)
            timer = 0;

        if (targetDistance < 0)
        {
            if(facingRight)
            {
                Flip();
            }
        }
        else
        {
            if (!facingRight)
            {
                Flip();
            }
        }
        if (timer > 0 && timer < 2)
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
        GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        if(facingRight)
        {
            tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        an.SetBool("Reload", true);
    }


}
