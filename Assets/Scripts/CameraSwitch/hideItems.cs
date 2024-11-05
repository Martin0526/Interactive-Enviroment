using UnityEngine;

public class hideItems : MonoBehaviour
{

    public cameraSwitch manager = new cameraSwitch();

    public GameObject[] item;

    void Update()
    {

        for (int idx = 0; idx < item.Length; idx++) 
        {
            GameObject obj = item[idx];
            if (manager.Manager == 0)
                obj.SetActive(false);

            if (manager.Manager == 1)
                obj.SetActive(true);
        }
    }
}
