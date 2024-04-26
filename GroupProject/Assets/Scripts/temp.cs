using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{

    public float speed;         // speed of the platform
    public int startingPoint;   // starting index (position of the platform)
    public Transform[] points;  // An array of transform points (positions where the platform needs to move)

    private int i;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = points[startingPoint].position; // Setting the position of the platform
                                                             // the position of one of the points using index "startingPoint"
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
{
    if (gameObject.activeSelf) // Check if Squaretest is active
    {
        collision.transform.SetParent(null);
    }
}

}
