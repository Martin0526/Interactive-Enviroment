using UnityEngine;

public class CanvasLookAtCam : MonoBehaviour
{

    public GameObject[] canvas;
    public Transform target;


    void Start()
    {
        
    }

    void Update()
    {

        for (int idx = 0; idx < canvas.Length; idx++)
        {
            GameObject obj = canvas[idx];

            obj.transform.LookAt(target) ;
        }


    }
}
