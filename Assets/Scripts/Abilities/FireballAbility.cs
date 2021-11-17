using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireballAbility : Ability
{
    private Vector3 destination;
    public GameObject projectile;
    public float range;
    public float launchVelocity;
    private Transform firePoint;
    public string shootingPointName = "FirePoint";

    public override void Activate(GameObject parent)
    {

        //Casts a ray from the Camera
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //Finds the position to instantiate the fireball
        firePoint = parent.transform.Find(shootingPointName);

        //The ray from the camera either hits a gameobject or nothing, if it hits something set the destination, otherwise gets a empty point in space depending on the range variable
        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(range);
        }
        //Launches the projectile if it exists
        if (projectile != null)
        {
            var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
            projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * launchVelocity;
        }
    }
}
