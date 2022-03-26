using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Add the key to the player's inventory
            other.gameObject.GetComponent<PlayerKeyCounter>().keys.Add(gameObject);
            // Hide the key
            gameObject.SetActive(false);
        }
    }

}
