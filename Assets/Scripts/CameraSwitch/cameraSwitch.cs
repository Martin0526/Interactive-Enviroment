using UnityEngine;

public class cameraSwitch : MonoBehaviour
{

    public GameObject FirstPerson;
    public GameObject PivotCamera;
    public int Manager;

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
    }


    void pivotCamera()
    {
        FirstPerson.SetActive(false);
        PivotCamera.SetActive(true);
    }

}
