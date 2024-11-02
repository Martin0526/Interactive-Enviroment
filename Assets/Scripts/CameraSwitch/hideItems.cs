using UnityEngine;

public class hideItems : MonoBehaviour
{

    public cameraSwitch manager = new cameraSwitch();

    public GameObject item;

    void Update()
    {
        if (manager.Manager == 0)
            item.SetActive(false);


        if (manager.Manager == 1)
            item.SetActive(true);

    }
}
