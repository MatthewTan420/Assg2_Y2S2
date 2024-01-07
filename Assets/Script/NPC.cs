using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public float firerate;
    public float nextfire;
    public float voiceTimer;
    public AudioSource aiVoice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextfire && animator != null)
        {
            nextfire = Time.time + firerate;
            animator.SetBool("isTalk", true);
            Invoke(nameof(Talking), 3.0f);
        }
    }

    private void Talking()
    {
        animator.SetBool("isTalk", false);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "OVRPlayerController")
        {
            aiVoice.Play();
            /*
            if (voiceTimer > 0)
            {
                animator.SetBool("isTalk", false);
            }*/
        }
        
    }

}
