using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{

    private float scale;
    private float time;

    RectTransform rectTransform;

    void Awake()
    {
       rectTransform = GetComponent<RectTransform>();
        scale = rectTransform.sizeDelta.x;
    }

    public void setInitValue(float time)
    {
        this.time = time;
    }

    public void setValue(float value)
    {
        float newScale = value * scale / time;
        rectTransform.sizeDelta = new Vector2(newScale, 0.1f);
    }
}
