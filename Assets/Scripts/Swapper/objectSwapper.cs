using UnityEngine;

public class objectSwapper : MonoBehaviour
{

    public MeshFilter firstMesh;
    public Mesh[] newMesh;

    int currentMesh;


    bool isNewMeshActive = false;
    Mesh oldMesh;

    
    void Start()
    {
        oldMesh = GetComponent<MeshFilter>().mesh;
    }

    public void SwapMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        isNewMeshActive = !isNewMeshActive;

        if (isNewMeshActive)
        {
            meshFilter.mesh = newMesh[currentMesh];
            currentMesh++;
        }

        if (currentMesh >= newMesh.Length)
        {
            currentMesh = 0;
        }

    }
    


}
