using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBox : MonoBehaviour
{
    public Material skyMaterial1;
    public Material skyMaterial2;
    public Material skyMaterial3;
    public Material skyMaterial4;

    public GameObject starting;
    public GameObject secondPoint;
    public GameObject thirdPoint;
    public GameObject ending;

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

        starting.SetActive(true);
        secondPoint.SetActive(false);
    }

    public void changeSky2()
    {
        RenderSettings.skybox = skyMaterial2;
        secondPoint.SetActive(true);
        starting.SetActive(false);
    }

    public void changeSky3()
    {
        RenderSettings.skybox = skyMaterial3;
        thirdPoint.SetActive(true);
        secondPoint.SetActive(false);
    }

    public void changeSky4()
    {
        RenderSettings.skybox = skyMaterial4;
        ending.SetActive(true);
        thirdPoint.SetActive(false);
    }

    public void changeSkyBack3()
    {
        RenderSettings.skybox = skyMaterial3;
        ending.SetActive(false);
        thirdPoint.SetActive(true);
    }
    public void changeSkyBack2()
    {
        RenderSettings.skybox = skyMaterial2;
        thirdPoint.SetActive(false);
        secondPoint.SetActive(true);
    }
    public void goToBunker()
    {
        SceneManager.LoadScene(2);
    }
}
