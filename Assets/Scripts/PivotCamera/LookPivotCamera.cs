using UnityEngine;

public class LookPivotCamera : MonoBehaviour
{

    public float sensX = 500f;
    public float sensY = 500f;
    public float ZoomSens = 50f;

    public float smoothTime = 0.1f;

    //private variables since "public" was left out
    float xCurrent;
    float yCurrent;
    
    float xTarget;
    float yTarget;


    float xCurrentVelocity;
    float yCurrentVelocity;
 

    public cameraSwitch manager = new cameraSwitch();

    //Making sure camera doesnt freak out at start
    void Start()
    {
        xTarget = xCurrent;    
        yTarget = yCurrent;    
  
    }

    
    void Update()
    {
        // Get usable mouse inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        float mouseZ = Input.GetAxisRaw("Mouse ScrollWheel") * Time.deltaTime * ZoomSens;

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

        if ((mouseZ) != 0)
        {
            transform.position += this.transform.forward * mouseZ * ZoomSens;
        }


        // Rotate camera
        xCurrent = Mathf.SmoothDamp(xCurrent, xTarget, ref xCurrentVelocity, smoothTime);
        yCurrent = Mathf.SmoothDamp(yCurrent, yTarget, ref yCurrentVelocity, smoothTime);

        transform.eulerAngles = new Vector3(yCurrent, xCurrent, 0f);


    }
}
