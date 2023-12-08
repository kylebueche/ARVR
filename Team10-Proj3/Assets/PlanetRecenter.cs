using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRecenter : MonoBehaviour
{

    public float returnSpeed = 2.0f;
    private bool shouldReturn = false;
    private float timer = 0f;
    private float delayTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if the delay time has passed
        if (!shouldReturn && timer >= delayTime)
        {
            shouldReturn = true;
            timer = 0f;
        }

        if (shouldReturn)
        {
            // Calculate the direction to move towards the origin (0, 0, 0)
            Vector3 directionToOrigin = Vector3.zero - transform.position;

            // Calculate the distance to the origin
            float distanceToOrigin = directionToOrigin.magnitude;

            // If the object is not already at the origin
            if (distanceToOrigin > 0.01f)
            {
                // Calculate the movement step towards the origin
                Vector3 movement = directionToOrigin.normalized * returnSpeed * Time.deltaTime;

                // Move the object towards the origin
                transform.Translate(movement);
            }
            else
            {
                // Snap the object to exactly (0, 0, 0) when close enough
                transform.position = Vector3.zero;
                shouldReturn = false; // Reset shouldReturn for future use

                // Reset rotation to (0, 0, 0)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, returnSpeed * Time.deltaTime);
            }
        }
    }
}
