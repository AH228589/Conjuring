using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;

    Vector2 horizontalInput;

    [SerializeField] float jumpHeight = 3.5f;
    bool jump;

    [SerializeField] float gravity = -30f; // -9.81
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    #endregion
    private void Update()
    {
        //Checking if controller is on the ground
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);

        //Removing vertical velocity if the object is grounded
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }

        //Horizontal movement
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump)
        {
            if (isGrounded)
            {
                //If the jump is pressed and the controller is grounded - jump
                // Jump: v = sqrt(-2 * jumpHeight * gravity)
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            //Resetting the jump
            jump = false;
        }

        //Applying basic gravity to let us get back to the ground
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    //This receives the input from the input system
    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed()
    {
        jump = true;
    }

}