using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    //Reference to movement and mouselook
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;

        //Binding the HorizontalMovement performed action to a context that reads a vector2
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        //Binds the jump to movement.OnJumpPressed setting it to true inside the movement script
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        //Binding the X and Y movements to the mouselook variables, reading the context value as float
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    //Toggles controls being enabled or disabled
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
}