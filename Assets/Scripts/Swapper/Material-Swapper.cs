using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    public GameObject[] SceneObjectList;
    public Material[] MaterialList;

    //bool isNewMaterialActive= false;
    //Material oldMaterial;
    int currentMat;

    void Start()
    {
        //MeshRenderer meshRenderer = GetComponent<MeshRenderer>();    
        //for (int idx = 0; idx < MaterialList.Length; idx++)
        //    meshRenderer.material = MaterialList[currentMat];
    }

    public void SwapMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        
        currentMat++;
        if (currentMat > MaterialList.Length-1)
            currentMat = 0;

        for (int idx = 0; idx < MaterialList.Length; idx++)
        {
            GameObject obj = SceneObjectList[idx];
            obj.GetComponent<MeshRenderer>().material = MaterialList[currentMat];
            //meshRenderer.material = MaterialList[currentMat];
        }

        //MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        //isNewMaterialActive = !isNewMaterialActive;

        //if (isNewMaterialActive)
        //    meshRenderer.material = newMaterial;
        //else
        //    meshRenderer.material = oldMaterial;
    }

    public void ChangeMatBackwards()
    {
        currentMat--;

        if (currentMat < 0)
            currentMat = SceneObjectList.Length - 1;


        for (int idx = 0; idx < MaterialList.Length; idx++)
        {
            GameObject obj = SceneObjectList[idx];
            obj.GetComponent<MeshRenderer>().material = MaterialList[currentMat];
        }
    }





}
