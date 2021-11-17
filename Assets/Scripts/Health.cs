using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyTarget), 0.5f);
        }
        //Debug.Log(health);
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
