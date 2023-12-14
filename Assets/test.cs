using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Animator animator;
    public Transform door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Key" && gameObject.tag == "Door")
        {
            animator.SetBool("isKey",true);
            collision.transform.SetParent(door);
        }

        if (collision.gameObject.tag == "Destroy" && gameObject.tag == "Weapon")
        {
            Destroy(collision.gameObject);
        }

        if (gameObject.tag == "Destroyer")
        {
            Destroy(collision.gameObject);
        }
    }
}
