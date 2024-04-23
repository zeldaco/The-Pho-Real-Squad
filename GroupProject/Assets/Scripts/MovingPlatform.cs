using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Vector2 pointA;
    public Vector2 pointB;
    public float speed = 2.0f;
    private float progress = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // calculate next position
        progress += Time.deltaTime * speed; 
        float pingPong = Mathf.PingPong(progress, 1);
        transform.position = Vector2.Lerp(pointA, pointB, pingPong);
    }
}
