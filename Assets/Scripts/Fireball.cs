using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float force = 5;
    public GameObject impactVFX;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyAi aiBrain = col.gameObject.GetComponent<EnemyAi>();
            aiBrain.TakeDamage(10);
            var impact = Instantiate(impactVFX, col.contacts[0].point, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
            Destroy(impact, 2);
        }
    }
}