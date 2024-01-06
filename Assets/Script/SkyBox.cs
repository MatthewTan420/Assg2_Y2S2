using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public Material skyMaterial1;
    public Material skyMaterial2;
    public Material skyMaterial3;
    public Material skyMaterial4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSky()
    {
        RenderSettings.skybox = skyMaterial1;
    }

    public void changeSky2()
    {
        RenderSettings.skybox = skyMaterial2;
    }

    public void changeSky3()
    {
        RenderSettings.skybox = skyMaterial3;
    }

    public void changeSky4()
    {
        RenderSettings.skybox = skyMaterial4;
    }

    public void changeSkyBack3()
    {

    }
}
