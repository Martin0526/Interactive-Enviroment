using UnityEngine;
using UnityEngine.UI;

public class Hoverobject : MonoBehaviour
{

    public Camera cam;

    void Start()
    {
        
    }


    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);

        }
    }
}
