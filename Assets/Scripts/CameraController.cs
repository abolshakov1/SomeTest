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

    void updatePosition(Vector3 center)
    {
        center.z = this.transform.position.z;
        this.transform.position = center;
    }

    void updateSize(Vector3 center)
    {
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

    void FixedUpdate() 
    {
        if (ballController)
        {
            var center = ballController.transform.position;
            updatePosition(center);
            updateSize(center);
        }
    }
}
