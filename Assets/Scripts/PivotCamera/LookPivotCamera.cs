using UnityEngine;

public class LookPivotCamera : MonoBehaviour
{

    public float sensX = 500f;
    public float sensY = 500f;

    public float smoothTime = 0.1f;

    //private variables since "public" was left out
    float xCurrent;
    float yCurrent;
    
    float xTarget;
    float yTarget;

    float xCurrentVelocity;
    float yCurrentVelocity;


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

        //Check if mouse drag
        if (Input.GetMouseButton(0))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            xTarget += mouseX;
            yTarget -= mouseY;

        }
        else
        { 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; 
        }

        // Rotate camera
        xCurrent = Mathf.SmoothDamp(xCurrent, xTarget, ref xCurrentVelocity, smoothTime);
        yCurrent = Mathf.SmoothDamp(yCurrent, yTarget, ref yCurrentVelocity, smoothTime);

        transform.eulerAngles = new Vector3(yCurrent, xCurrent, 0f);


    }
}
