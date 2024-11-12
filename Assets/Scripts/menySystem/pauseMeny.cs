using UnityEngine;

public class pauseMeny : MonoBehaviour
{

    public Canvas pauseMenu;
    public cameraSwitch manager = new cameraSwitch();

    //Private Variables
    public bool pauseActive = false;

    void Start()
    {
        pauseMenu.enabled = false;
        pauseActive = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.enabled = true;
            pauseActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log(pauseActive);
        }
    }

    public void unPause()
    {
        pauseMenu.enabled = false;
        pauseActive = false;
        Debug.Log(pauseActive);
    }


    public void exit()
    {
        Application.Quit();
    }
}
