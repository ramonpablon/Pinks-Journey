using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Enemy
{
    public bool fired = false;

    public int damage = 1;

    public int newton;

    // Use this for initialization
    void Start(){
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (!fired)
        {
            rb.AddForce(transform.right * newton * Time.fixedDeltaTime, ForceMode2D.Impulse);
            fired = true;
        }

    }

    void Fire()
    {
        fired = true;
    }

    private void OnTriggerEnter2D(Collider2D trigg)
    {
        if(trigg.gameObject.tag.Equals("Ground"))
        {
            Instantiate(deathAnimation, transform.position, trigg.transform.rotation);
            Destroy(gameObject);
        }
        if(trigg.gameObject.tag.Equals("Boss"))
        {
            trigg.gameObject.SendMessage("TookDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
        if(trigg.gameObject.tag.Equals("Taco"))
        {
            transform.localEulerAngles = new Vector3(0, 0, 120);

            rb.AddForce(transform.up * -newton * 2f* Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    } 
}
