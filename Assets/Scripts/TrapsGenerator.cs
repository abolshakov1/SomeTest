using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsGenerator : MonoBehaviour
{
    [SerializeField] GameObject singleTrap;
    [SerializeField] LevelSettings levelSettings;
    
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;

    private List<GameObject> traps;

    void Start() {
        traps = new List<GameObject>();    
    }

    void Update()
    {
        if (traps.Count != levelSettings.trapsCount)
        {
            for (int i = 0; i < (levelSettings.trapsCount - traps.Count); ++i)
            {
                traps.Add(createTrap());
            }
        }
    }

    GameObject createTrap()
    {
        var trap = Instantiate(singleTrap, Vector3.zero, Quaternion.identity);
        Points points = trap.GetComponent<Points>();

        var first = points.first;
        first.transform.position = pickPoint(levelSettings.levelRect);

        float distance = Random.Range(minDistance, maxDistance);

        Rect rect = new Rect(first.transform.position, new Vector2(distance, distance));
        
        var second = points.second;

        Vector2 secondPoint = pickPoint(rect);
        second.transform.position = secondPoint;

        return trap;
    }

    Vector2 pickPoint(Rect rect)
    {
        float x = Random.Range(rect.xMin, rect.xMax);
        float y = Random.Range(rect.yMin, rect.yMax);

        return new Vector2(x, y);
    }

}
