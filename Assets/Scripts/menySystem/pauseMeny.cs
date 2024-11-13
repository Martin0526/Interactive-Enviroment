using UnityEngine;

public class pauseMeny : MonoBehaviour
{

    public Canvas pauseMenu;
    public Canvas controlMenu;
    public cameraSwitch manager = new cameraSwitch();

    
    public bool pauseActive = false;

    void Start()
    {
        controlMenu.enabled = false;
        pauseMenu.enabled = false;
        pauseActive = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            pauseMenu.enabled = true;
            pauseActive = true;
        }
    }

    public void unPause()
    {
        pauseMenu.enabled = false;
        pauseActive = false;
    }

    public void control()
    {
        controlMenu.enabled = true;
        pauseMenu.enabled = false;
        
    }

    public void backControl()
    {
        controlMenu.enabled = false;
        pauseMenu.enabled = true;
        
    }



    public void exit()
    {
        Application.Quit();
    }
}
