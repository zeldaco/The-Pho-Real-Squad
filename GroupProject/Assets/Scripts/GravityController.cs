using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private bool gravityUp = false;
    public bool IsGravityUp => gravityUp;
    private Quaternion targetRotation;
    private Transform characterTransform;

    private float gravityFlipCooldown = 1.0f; // Time in seconds between gravity flips
    private float lastGravityFlipTime = -2.0f; // Initialize to ensure gravity can flip at start

    private void Start()
    {
        characterTransform = this.transform;
        targetRotation = characterTransform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time - lastGravityFlipTime >= gravityFlipCooldown)
        {
            lastGravityFlipTime = Time.time; // Update the last flip time
            gravityUp = !gravityUp;

            if (gravityUp)
            {
                Physics2D.gravity = new Vector2(0, 9.8f);
                targetRotation = Quaternion.Euler(180, 0, 0);
            }
            else
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
                targetRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        // Gradually rotate the character to the target rotation
        characterTransform.rotation = Quaternion.Slerp(characterTransform.rotation, targetRotation, Time.deltaTime * 5);
    }
}
