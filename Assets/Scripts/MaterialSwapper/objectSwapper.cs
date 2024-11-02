using UnityEngine;

public class objectSwapper : MonoBehaviour
{

    public MeshFilter firstMesh;
    public Mesh newMesh;


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
            meshFilter.mesh = newMesh;
        else
            meshFilter.mesh = oldMesh;
    }
    


}
