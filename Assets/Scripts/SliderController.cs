using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{

    private float scale;
    private float time;

    void Awake()
    {
       scale = this.transform.localScale.x;
    }

    public void setInitValue(float time)
    {
        this.time = time;
    }
    public void setValue(float value)
    {
      float newScale = value * scale / time;
      this.transform.localScale = new Vector3(newScale, 0.3f, 1);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
