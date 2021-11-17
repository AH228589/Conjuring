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
        //Casts a ray from the Camera
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //The ray from the camera either hits a gameobject or nothing, if it hits something set the destination, otherwise gets a empty point in space depending on the range variable
        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(range);
        }

        //Spawns a platform at the destination
        if (platform != null)
        {
            var platformObj = Instantiate(platform, destination, Quaternion.identity);
        }
    }
}
