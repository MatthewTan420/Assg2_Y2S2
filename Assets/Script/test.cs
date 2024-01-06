using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public Animator animator;
    public Transform door;
    public Grabbable Grabbable;
    public GameObject breakObj;
    public GameObject bulbFix;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scene()
    {
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Key" && gameObject.tag == "Door")
        {
            animator.SetBool("isKey",true);
            collision.transform.SetParent(door);
            Grabbable.enabled = false;
        }

        if (collision.gameObject.tag == "Bulb" && gameObject.tag == "Lamp")
        {
            collision.transform.SetParent(door);
            bulbFix.SetActive(true);
        }

        if (collision.gameObject.tag == "Destroy" && gameObject.tag == "Weapon")
        {
            Instantiate(breakObj, transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }

        if (gameObject.tag == "Destroyer")
        {
            Destroy(collision.gameObject);
        }
    }
}
