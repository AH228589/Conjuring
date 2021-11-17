using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;
    public override void Activate(GameObject parent)
    {
        Movement movement = parent.GetComponent<Movement>();
        CharacterController characterController = parent.GetComponent<CharacterController>();

        characterController.Move(parent.transform.forward * dashVelocity);
    }
}
