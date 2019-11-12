using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public AnimationCurve curve;
    public int count;
    public GameObject coin;

    float timeElapsed;

    Rigidbody2D rb;

    void Start()
    {
        timeElapsed = 0;
        rb = coin.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        rb.MovePosition(transform.position + new Vector3(curve.Evaluate(timeElapsed), curve.Evaluate(timeElapsed) * 3, 0)  );

        timeElapsed += Time.deltaTime;
    }
}
