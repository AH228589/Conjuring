using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlinkAbility : Ability
{
    public float blinkDistance;
    public override void Activate(GameObject parent)
    {
        //Teleports the character in the forward direction based on the distance variable
        CharacterController characterController = parent.GetComponent<CharacterController>();
        characterController.Move(parent.transform.forward * blinkDistance);
    }
}
