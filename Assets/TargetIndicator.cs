using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField] GameObject childArrow;

    private GameObject goal;
    private float angle;
    
    void Update()
    {
        if (goal == null)
        {
            goal = GameObject.FindGameObjectWithTag("Finish");
        }
        else
        {
            var lookAt = (Vector2)goal.transform.position - (Vector2)transform.position;
            angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;

            Rect camBounds = cameraRect();
            if (camBounds.Contains(goal.transform.position))
            {   
                childArrow.GetComponent<Renderer>().enabled = false;
            }
            else if (!childArrow.GetComponent<Renderer>().enabled)
            {
                childArrow.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
   
    public Rect cameraRect()
    {
         float screenAspect = (float)Screen.width / (float)Screen.height;
         float cameraHeight = Camera.main.orthographicSize * 2;
         Bounds bounds = new Bounds(
             Camera.main.transform.position,
             new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        return new Rect(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y, bounds.size.x, bounds.size.y);
    }


}
