using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    BallController ballController;
    GameObject playerBall;
    Camera camera;

    public float borderToIncreaseSize;
    public float defaultSize;
    public float maxSize;
    public float increase;

    void Awake()
    {
        playerBall = GameObject.FindGameObjectWithTag("Player");
        ballController = playerBall.GetComponent<BallController>();
        camera = this.GetComponent<Camera>();
        defaultSize = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        var center = ballController.transform.position;
        center.z = this.transform.position.z;
        this.transform.position = center;

        if (center.y > borderToIncreaseSize)
        {
           maxSize = center.y + defaultSize;
           if (camera.orthographicSize < maxSize)
           {
                camera.orthographicSize += increase;
           }
        }

        if (center.y < borderToIncreaseSize && camera.orthographicSize > defaultSize) 
        {
            camera.orthographicSize -= increase;
        }

    }
}
