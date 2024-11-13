using UnityEngine;

public class cameraSwitch : MonoBehaviour
{

    public GameObject FirstPerson;
    public GameObject PivotCamera;
    public int Manager;

    private void Start()
    {
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            GetComponent<Animator>().SetTrigger("changeCamera");
    }

    public void ManageCamera()
    {
        if (Manager == 0)
        {
            pivotCamera();
            Manager = 1;
        }
        else
        {
            firstPerson();
            Manager = 0;
        }



    }

    void firstPerson()
    {
        FirstPerson.SetActive(true);
        PivotCamera.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    void pivotCamera()
    {
        FirstPerson.SetActive(false);
        PivotCamera.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

}
