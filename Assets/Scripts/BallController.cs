using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{   
    CircleCollider2D collider;
    Rigidbody2D rigidbody;
    public bool slowmotionOn;
    public Vector3 startDragPoint;
    public Vector3 endDragPoint;
    LineRenderer lineRenderer;

    bool addForce;

    void Awake()
    {
        collider = this.GetComponent<CircleCollider2D>();
        rigidbody = this.GetComponent<Rigidbody2D>();

        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        addForce = false;
    }

    void Update()
    {   
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos =  new Vector3(mousePos.x, mousePos.y, this.transform.position.z);

        if (!slowmotionOn && Input.GetKeyDown(KeyCode.Mouse0) && collider.bounds.Contains(pos))
        {
            startClick(pos);

        }
        else if (slowmotionOn && Input.GetKeyUp(KeyCode.Mouse0) && rigidbody.simulated == false)
        {
            finishClick();
        }

        if (slowmotionOn)
            lineRenderer.SetPosition(1, pos);

        endDragPoint = pos;
    }

    void finishClick()
    {
        rigidbody.simulated = true;
        slowmotionOn = false;

        addForce = true;
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 0;
    }

    void startClick(Vector3 pos)
    {
        rigidbody.simulated = false;
        slowmotionOn = true;

        startDragPoint = pos;
        
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = 0;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.enabled = true;
    }

    void FixedUpdate()
    {
        if (addForce)
        {
            rigidbody.AddForce(toVector2(startDragPoint - endDragPoint) * 50, ForceMode2D.Force);
            addForce = false;
        }
    }

    Vector2 toVector2(Vector3 vec)
    {
        return new Vector2(vec.x, vec.y);
    }


}
