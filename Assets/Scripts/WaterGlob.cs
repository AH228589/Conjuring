using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGlob : MonoBehaviour
{

    public float force = 5;
    public GameObject impactVFX;
    public GameObject waterGlob;
    public int maxBounceAmmount = 3;
    public int currBounceAmmount = 0;

    void OnCollisionEnter(Collision col)
    {
        var impact = Instantiate(impactVFX, col.contacts[0].point, Quaternion.identity) as GameObject;

        if (currBounceAmmount <= maxBounceAmmount)
        {
            Debug.Log("Bounced");
            maxBounceAmmount++;
            if (currBounceAmmount == 1)
            {
                var water = Instantiate(waterGlob, this.transform.position, Quaternion.identity) as GameObject;
                Debug.Log("Split");
            }
        }
        if (currBounceAmmount >= maxBounceAmmount)
        {
            Debug.Log("Bounced Enough");
            Destroy(this.gameObject);
        }
        Destroy(impact, 2);
    }
}