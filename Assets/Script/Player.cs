using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public Timer Timer;
    public GameObject UI;
    public GameObject end;
    public CharacterController cc;
    public AuthManager authManager;
    public int timeFin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            Timer.timer += 10.0f;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayGame")
        {
            UI.SetActive(true);
        }

        if (collision.gameObject.tag == "EndGame")
        {
            Timer.isEnd = true;
            end.SetActive(true);
            timeFin = (int)Timer.timer;
            cc.enabled = false;

            if (timeFin >= Timer.orgTime)
            {
                authManager.UpdateData(timeFin, 5);
            }
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "PlayGame")
        {
            UI.SetActive(false);
        }
    }

    public void ReloadScene()
    {
        // use the SceneManager to load the specified scene index.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
