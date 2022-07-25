using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarResourceControl : MonoBehaviour
{
    public string resourceName;
    private float maxValue;
    private Vector3 barFullPosition;
    public RectTransform bar;

    private void Change(float resourceValue)
    {
        var newPosition = barFullPosition;

        var barWidth = bar.rect.width;
        newPosition.x -= barWidth * (1 - resourceValue / maxValue);

        bar.position = newPosition;
    }

    private void Start()
    {
        var resource = PlayerResource.Find(resourceName);
        maxValue = resource.GetMaxValue();
        barFullPosition = bar.position;
        Change(resource.GetValue());
        resource.ValueChangeEvent += Change;
    }
}
