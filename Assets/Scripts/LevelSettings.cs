using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{

    public Rect levelRect;
    public int trapsCount;

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube((Vector3)levelRect.center, (Vector3)levelRect.size);    
    }

}
