using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProgressBar : MonoBehaviour
{
    Texture2D emptyTexture;
    Texture2D fillTexture;

    public float progress;

    [Range(0, 500)]
    public int width;
    [Range(0, 500)]
    public int height;

    Vector2 pos;

    public Color emptyColor;
    public Color fillColor;

    void drawTexture(Texture2D texture, Color color)
    {   
        var fillColorArray =  texture.GetPixels();
        for(var i = 0; i < fillColorArray.Length; ++i)
        {
             fillColorArray[i] = color;
        }
    }

    void Awake()
    {
        pos = this.transform.position;        
        
        emptyTexture = new Texture2D(width, height);
        fillTexture = new Texture2D(width, height);

        drawTexture(emptyTexture, emptyColor);
        drawTexture(fillTexture, fillColor);
    }


    void Update()
    {
        
    }

    void OnGUI()
    {
        var size = new Vector2(width, height);

        // GUI.BeginGroup(new Rect(pos, size));

            GUI.Box(new Rect(Vector2.zero,  size), emptyTexture);
            
            GUI.BeginGroup(new Rect(Vector2.zero, new Vector2(size.x * progress, size.y)));
                GUI.Box(new Rect(Vector2.zero, size ), fillTexture);
            // GUI.EndGroup();

        // GUI.EndGroup();
    }
}
