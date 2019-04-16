using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public GameObject explosionEffect;
    public float innerForce = 500f;
    public float outerForce = 250f;
    private float timer = 0f;
    private float innerRadius = .5f;
    private float outerRadius = 1f;
    bool hasExploded = false;
    private void Start()
    {
        timer = 1f;
    }
    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;
        
        if(timer < 0 && !hasExploded)
        {
            timer = 5f;
            explosion();
            hasExploded = true;
        }
	}
    // fix so that player cannot damage enemy during explosions
    private void explosion()
    {
        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //get nearby objects
        Collider [] colliders = Physics.OverlapSphere(transform.position, innerRadius);
        Collider[] collidersOuter = Physics.OverlapSphere(transform.position, outerRadius);
        
        //2 level damage, the closer the play is to the tnt the more damage the player takes
        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if(rb != null && rb.tag == "Player")
            {
                rb.AddExplosionForce(innerForce, transform.position, innerRadius);
                player.P.takeDamage(2);
            }
        }
        foreach (Collider nearby in collidersOuter)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null && rb.tag == "Player")
            {
                rb.AddExplosionForce(outerForce, transform.position, outerRadius);
                player.P.takeDamage(1);
            }
        }
        //damage the player
       Destroy(gameObject);
    }
}
