using Unity.VisualScripting;
using UnityEngine;

public class light_Controls : MonoBehaviour
{
    [Header("Skybox")]
    public Material[] skyboxMatList;

    [Header("Light Temperature")]
    public Light light1;
    public Light light2;
    public Light light3;
    public float[] lightTemp;
    public float maxChange = 4000f;

    [Header("Light intensity")]
    public float[] lightIntensity;
    public float maxChange2 = 5f;

    //Private Variables
    int selectedIndex = 0;
    int lightIndex = 0;
    int lightIntensityIdx = 0;

    void Start()
    {
        RenderSettings.skybox = skyboxMatList[0];
        light1.colorTemperature = light1.colorTemperature;
        light2.colorTemperature = light2.colorTemperature;
        light3.colorTemperature = light3.colorTemperature;

        light1.intensity = light1.intensity;
        light2.intensity = light2.intensity;
        light3.intensity = light3.intensity;

        selectedIndex = 0;
    }

    void Update()
    {
        //Color temp Change
        light1.colorTemperature = Mathf.MoveTowards(light1.colorTemperature, lightTemp[lightIndex], maxChange * Time.deltaTime);
        light2.colorTemperature = Mathf.MoveTowards(light2.colorTemperature, lightTemp[lightIndex], maxChange * Time.deltaTime);
        light3.colorTemperature = Mathf.MoveTowards(light3.colorTemperature, lightTemp[lightIndex], maxChange * Time.deltaTime);

        //Intensity Change
        light1.intensity = Mathf.MoveTowards(light1.intensity, lightIntensity[lightIntensityIdx], maxChange2 * Time.deltaTime);
        light2.intensity = Mathf.MoveTowards(light2.intensity, lightIntensity[lightIntensityIdx], maxChange2 * Time.deltaTime);
        light3.intensity = Mathf.MoveTowards(light3.intensity, lightIntensity[lightIntensityIdx], maxChange2 * Time.deltaTime);
        //Debug.Log(light1.intensity);
    }


    public void changeSkyboxForward()
    {

        selectedIndex++;

        if (selectedIndex > skyboxMatList.Length - 1)
            selectedIndex = 0;

        for (int idx = 0; idx < skyboxMatList.Length; idx++)
        {

            RenderSettings.skybox = skyboxMatList[selectedIndex];

        }
    }

    public void changeSkyboxBackward()
    {

        selectedIndex--;

        if (selectedIndex < 0)
            selectedIndex = skyboxMatList.Length - 1;

        for (int idx = 0; idx < skyboxMatList.Length; idx++)
        {

            RenderSettings.skybox = skyboxMatList[selectedIndex];

        }

    }

    public void lightTempForward()
    {
        lightIndex++;

        if (lightIndex > lightTemp.Length - 1)
            lightIndex = 0;
    }

    public void lightTempBack()
    {
        lightIndex--;

        if (lightIndex < 0)
            lightIndex = lightTemp.Length - 1;
    }

    public void lightIntensityForward()
    {
        lightIntensityIdx++;

        if (lightIntensityIdx > lightIntensity.Length - 1)
            lightIntensityIdx = 0;
        Debug.Log(lightIntensityIdx);
    }

    public void lightIntensityBack()
    {
        lightIntensityIdx--;

        if (lightIntensityIdx < 0)
            lightIntensityIdx = lightIntensity.Length - 1;
    }


}
