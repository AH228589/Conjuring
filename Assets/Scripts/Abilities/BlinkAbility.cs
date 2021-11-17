using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlinkAbility : Ability
{
    public float dashVelocity;
    public override void Activate(GameObject parent)
    {
        CharacterController characterController = parent.GetComponent<CharacterController>();
        characterController.Move(parent.transform.forward * dashVelocity);
    }
}
