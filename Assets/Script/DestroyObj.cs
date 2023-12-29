using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DesObj), 3.0f);
    }

    private void DesObj()
    {
        Destroy(gameObject);
    }
}
