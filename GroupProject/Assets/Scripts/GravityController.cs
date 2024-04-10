using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private bool gravityUp = false;
    public bool IsGravityUp => gravityUp;
    private Quaternion targetRotation;
    private Transform characterTransform; // Assume this is the transform of the character

    private void Start()
    {
        characterTransform = this.transform; // Or assign the character's transform however you see fit
        targetRotation = characterTransform.rotation; // Initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gravityUp = !gravityUp;

            if (gravityUp)
            {
                Physics2D.gravity = new Vector2(0, 9.8f);
                targetRotation = Quaternion.Euler(180, 0, 0); // Target rotation for gravity up
            }
            else
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
                targetRotation = Quaternion.Euler(0, 0, 0); // Target rotation for gravity down
            }
        }

        // Gradually rotate the character to the target rotation
        characterTransform.rotation = Quaternion.Slerp(characterTransform.rotation, targetRotation, Time.deltaTime * 5); // Adjust 5 to your liking for speed
    }
}