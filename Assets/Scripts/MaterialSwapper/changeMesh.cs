using UnityEngine;

public class changeMesh : MonoBehaviour
{

    public MeshFilter firstMesh;
    public Mesh newMesh;



    void Update()
    {
       
    }

    public void ChangeMeshWithbutton()
    {
        firstMesh.mesh = newMesh;
    }

    
}
