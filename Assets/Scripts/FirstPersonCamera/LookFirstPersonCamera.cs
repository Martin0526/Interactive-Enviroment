using UnityEngine;


[RequireComponent (typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class LookFirstPersonCamera : MonoBehaviour
{
    //public variables
    public float sensX = 500f;
    public float sensY = 500f;

    public new Transform camera;
    public float eyeHeight = 1f;

    // Private Variables
    float xRotation;
    float yRotation;

    public cameraSwitch manager = new cameraSwitch ();
    public pauseMeny pause = new pauseMeny ();

    //Lock mouse & hide it, Set camera to eye height
    void Start()
    {
        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = cameraTargetPosition;
    }

    public void hideMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void showMouse()
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }

 

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
            showMouse();

        // Create usable mouse movement inputs
        if (pause.pauseActive == false)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
        }

        //Prevent camera turning upside down by clamping it
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Set rotation of camera and character
        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        camera.eulerAngles = new Vector3(xRotation, yRotation, 0f);
        
        // Move camera
        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = Vector3.Lerp(camera.position, cameraTargetPosition, 0.5f);
      

    }
}
