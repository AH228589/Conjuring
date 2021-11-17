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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        firePoint = parent.transform.Find(shootingPointName);

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(range);
        }
        if (projectile != null)
        {
            var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
            projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * launchVelocity;
        }
    }
}
