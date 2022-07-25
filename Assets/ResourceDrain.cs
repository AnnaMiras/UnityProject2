using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDrain : MonoBehaviour
{
    public string resourceName;
    public float drainPerSecond = 0.3f;
    private PlayerResource resource;

    void Start()
    {
        resource = PlayerResource.Find(resourceName);
    }

    void Update()
    {

        resource.ChangeValue(-drainPerSecond * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("fountain"))
        {
            drainPerSecond = Mathf.Abs(drainPerSecond) * -1;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("fountain"))
        {
            drainPerSecond = Mathf.Abs(drainPerSecond);
        }
    }
    // void OnTriggerEnter(Collision collision)
    // {
    //     Debug.Log("Entered");
    //     if (collision.CompareTag("fountain"))
    //     {
    //         drainPerSecond = Mathf.Abs(drainPerSecond) * -1;
    //     }
    // }
    // void OnTriggerExit(Collision collision)
    // {
    //     Debug.Log("Exited");
    //     if (collision.gameObject.CompareTag("fountain"))
    //     {
    //         drainPerSecond = Mathf.Abs(drainPerSecond);
    //     }
    // }
}
