using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    [SerializeField] public string resourceName;
    [SerializeField] public float value;

    public void CollectResource(bool destroyObject)
    {
        PlayerResource.Find(resourceName).ChangeValue(value);
        if (destroyObject)
        {
            Destroy(gameObject);
        }
    }
}
