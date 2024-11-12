using UnityEngine;


public class Meshlist : MonoBehaviour
{

    //public Mesh[] MeshList;

    public GameObject[] SceneObjectList;
    int selectedIndex = 0;



    //Collider Col;
    //int currentMesh;

    private void Start()
    {
        //  Col = GetComponent<MeshCollider>();
        for (int idx = 0; idx < SceneObjectList.Length; idx++)
        {
            GameObject obj = SceneObjectList[idx];
            obj.SetActive(idx == selectedIndex);
        }
    }


    public void ChangeMeshWithbutton()
    {

        //MeshFilter meshFilter = GetComponent<MeshFilter>();
        //MeshCollider collider = GetComponent<MeshCollider>();

        //meshFilter.mesh = MeshList[currentMesh];
        //collider.sharedMesh = MeshList[currentMesh];
        //currentMesh++;

        //if (currentMesh >= MeshList.Length)
        //    currentMesh = 0;


        selectedIndex++;

        if (selectedIndex > SceneObjectList.Length-1)
            selectedIndex = 0;


        for (int idx = 0; idx < SceneObjectList.Length; idx++)
        {
            GameObject obj = SceneObjectList[idx];
            obj.SetActive(idx == selectedIndex);
        }

        
    
    }

    public void ChangeMeshBackwards()
    {
        selectedIndex--;

        if (selectedIndex < 0)
            selectedIndex = SceneObjectList.Length-1;


        for (int idx = 0; idx < SceneObjectList.Length; idx++)
        {
            GameObject obj = SceneObjectList[idx];
            obj.SetActive(idx == selectedIndex);
        }
    }




}
