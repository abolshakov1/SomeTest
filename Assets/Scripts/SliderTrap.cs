using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTrap : MonoBehaviour
{
    [SerializeField] List<GameObject> points;
    [SerializeField] float speed;
    [SerializeField] bool cycled;
    [SerializeField] float rotateSpeed;

    private Rigidbody2D rigidbody;

    private Vector3 currentDirection;
    private int directionPointIndex;
    private int implicator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform.position = points[0].transform.position;

        directionPointIndex = 1;
        implicator = 1;

        currentDirection = getDirection(directionPointIndex);
    }
    
    Vector3 getDirection(int index)
    {
        return (points[index].transform.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + currentDirection * speed * Time.fixedDeltaTime);
        
        if (rotateSpeed != 0)
        {
            transform.Rotate(Vector3.forward * rotateSpeed, Space.World);
        }
    }

    void detectNextPoint()
    {
        if (cycled && directionPointIndex == points.Count - 1)
        {
            directionPointIndex = 0;
            currentDirection = getDirection(directionPointIndex);
            implicator *= -1;
            return;
        }
        else if (directionPointIndex == points.Count - 1 || 
            directionPointIndex == 0)
        {
            implicator *= -1;
        }

        directionPointIndex += implicator;
        currentDirection = getDirection(directionPointIndex);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, points[directionPointIndex].transform.position) < 0.1f)
        {   
            detectNextPoint();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (points.Count > 1)
        {
            var point = points[0];
            for (int i = 1; i < points.Count; ++i)
            {
                Gizmos.DrawLine(point.transform.position, points[i].transform.position);
                point = points[i];
            }

            if (cycled)
            {
                Gizmos.DrawLine(point.transform.position, points[0].transform.position);
            }
        }
    }
}
