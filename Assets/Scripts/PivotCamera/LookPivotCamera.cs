using Unity.Hierarchy;
using UnityEngine;

public class LookPivotCamera : MonoBehaviour
{
    [Header("Camera Pivot")]
    public float sensX = 500f;
    public float sensY = 500f;
    public float smoothTime = 0.1f;

    [Header("Camera Zoom")]
    public Camera cam;
    public Transform Target;
    public float MinZoom = 1.0f;
    public float MaxZoom = 6.0f;
    public float ZoomSpeed = 470f;

   

    //private variables since "public" was left out
    float xCurrent;
    float yCurrent;
    
    float xTarget;
    float yTarget;

    float xCurrentVelocity;
    float yCurrentVelocity;

    float currentZoom;

    public cameraSwitch manager = new cameraSwitch();

    //Making sure camera doesnt freak out at start
    void Start()
    {
        xTarget = xCurrent;    
        yTarget = yCurrent;

        currentZoom = Vector3.Distance(cam.transform.position, Target.position);
    }

    
    void Update()
    {
        // Get usable mouse inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        float scrollInput = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime ;

        if (manager.Manager == 1)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //Check if mouse drag
        if (Input.GetMouseButton(0))
        {

            xTarget += mouseX;
            yTarget -= mouseY;

        }

        if ((scrollInput) != 0)
        {

            currentZoom -= scrollInput * ZoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, MinZoom, MaxZoom);

            cam.transform.position = Target.position - cam.transform.forward * currentZoom;

        }


        // Rotate camera
        xCurrent = Mathf.SmoothDamp(xCurrent, xTarget, ref xCurrentVelocity, smoothTime);
        yCurrent = Mathf.SmoothDamp(yCurrent, yTarget, ref yCurrentVelocity, smoothTime);

        transform.eulerAngles = new Vector3(yCurrent, xCurrent, 0f);


    }
}
