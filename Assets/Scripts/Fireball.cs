using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float force = 5;
    public GameObject impactVFX;

    void OnCollisionEnter(Collision col)
    {
        //If the tag of the collided with object is either Player or Enemy, reduce the health by 10
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            Health health = col.gameObject.GetComponent<Health>();
            health.TakeDamage(10);
        }

        //Instantiates a particle effect at the point of impact, destroying the fireball and desotrying the particle effect after 2 seconds
        var impact = Instantiate(impactVFX, col.contacts[0].point, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
        Destroy(impact, 2);
    }
}