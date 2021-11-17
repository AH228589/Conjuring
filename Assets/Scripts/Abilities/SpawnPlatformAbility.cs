using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnPlatformAbility : Ability
{
    private Vector3 destination;
    public GameObject platform;
    public float range;
    public override void Activate(GameObject parent)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(range);
        }
        if (platform != null)
        {
            var platformObj = Instantiate(platform, destination, Quaternion.identity);
        }
    }
}
