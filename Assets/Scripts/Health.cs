using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    //Reduces the target health by the damage ammount
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyTarget), 0.5f);
        }
    }

    public void Heal(int healAmmount)
    {
        health += healAmmount;
    }

    public void DestroyTarget()
    {
        Manager gameManager = GameObject.Find("GameManager").GetComponent<Manager>();
        if (this.gameObject.name != "Player")
        {
            gameManager.playerScore += 100;
            Destroy(gameObject);
        }
        else
        {
            gameManager.GameOver();
        }
    }
}
