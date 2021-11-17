using UnityEngine;

public class MouseLook : MonoBehaviour
{

    #region Variables
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float yClamp = 85f;
    float yRotation = 0f;
    #endregion
    private void Start()
    {
        //Locking the cursor to the center of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Rotates the player body orientation based on the mouseX input
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        //Clamping on the Y axis to prevent camera going backwards
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -yClamp, yClamp);
        
        //Setting camera rotation
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = yRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    //Called in the input manager
    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

}