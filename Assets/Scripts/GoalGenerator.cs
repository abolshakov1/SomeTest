using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalGenerator : MonoBehaviour
{   
    [SerializeField] LevelSettings levelSettings;
    
    [SerializeField] GameObject player;
    [SerializeField] GameObject goalPrefab;


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
        float x = Random.Range(levelSettings.levelRect.xMin, levelSettings.levelRect.xMax);
        float y = Random.Range(levelSettings.levelRect.yMin, levelSettings.levelRect.yMax);

        return new Vector2(x, y);
    }
}
