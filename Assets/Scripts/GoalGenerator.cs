using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalGenerator : MonoBehaviour
{   
    [SerializeField] GameObject player;
    [SerializeField] GameObject goalPrefab;

    [SerializeField] Rect instanceSquare;

    private GameObject goalInstance;

    void Update()
    {   
        // TODO optimize this
        if (goalInstance == null)
        {
            createGoal();
        }
    }

    void createGoal()
    {
        var point = choosePoint();
        goalInstance = Instantiate(goalPrefab, point, Quaternion.identity);
    }

    Vector2 choosePoint()
    {
        float x = Random.Range(instanceSquare.xMin, instanceSquare.xMax);
        float y = Random.Range(instanceSquare.yMin, instanceSquare.yMax);

        return new Vector2(x, y);
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube((Vector3)instanceSquare.center, (Vector3)instanceSquare.size);    
    }
}
