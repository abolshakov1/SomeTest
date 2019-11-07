using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    BallController ballController;
    GameObject playerBall;
    Camera camera;

    [SerializeField] float borderToIncreaseSize;
    [SerializeField]
    float increase;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;

    float defaultOrthoSize;
    float maxOrthoSize;

    [SerializeField] bool changeSize;

    void Awake()
    {
        playerBall = GameObject.FindGameObjectWithTag("Player");
        ballController = playerBall.GetComponent<BallController>();
        camera = this.GetComponent<Camera>();
        defaultOrthoSize = camera.orthographicSize;
    }

    void updatePosition(Vector3 center)
    {
        center.z = this.transform.position.z;
        center.x += xOffset;
        center.y += yOffset;

        this.transform.position = center;
    }

    void updateSize(Vector3 center)
    {
        if (center.y > borderToIncreaseSize)
        {
           maxOrthoSize = center.y + defaultOrthoSize;
           if (camera.orthographicSize < maxOrthoSize)
           {
                camera.orthographicSize += increase;
           }
        }

        if (center.y < borderToIncreaseSize && camera.orthographicSize > defaultOrthoSize)
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
            if (changeSize)
              updateSize(center);
        }
    }
}
