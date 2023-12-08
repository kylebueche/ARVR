using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPaths : MonoBehaviour
{
    public Transform solarSystem;
    public float orbitRadiusScale = 1.0f;
    public float orbitSpeedScale = 1.0f;

    /*private Vector3[] originalPositions;
    private Quaternion[] originalRotations;
    private bool isInteracted = false;*/


    // Start is called before the first frame update
    void Start()
    {
        /*int childCount = transform.childCount;
        originalPositions = new Vector3[childCount];
        originalRotations = new Quaternion[childCount];

        // Store original positions and rotations
        for (int i = 0; i < childCount; i++)
        {
            Transform planet = transform.GetChild(i);
            originalPositions[i] = planet.position;
            originalRotations[i] = planet.rotation;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform planet = transform.GetChild(i);

            // Calculate the orbit distance (radius) based on the object's position relative to the center
            float orbitRadius = Vector3.Distance(solarSystem.position, planet.position);
             
            // Get the orbit speed, and rotation speed from values attached to the individual orbiting planets
            PlanetProperties planetProperties = planet.GetComponent<PlanetProperties>();
            float orbitSpeed = (planetProperties ? planetProperties.orbitSpeed : 0.0f) * orbitSpeedScale;
            float rotationSpeed = (planetProperties ? planetProperties.rotationSpeed : 0.0f);

            // Calculate the orbit position based on time and planet parameters
            Vector3 orbitPos = solarSystem.position + Quaternion.Euler(0, orbitSpeed * Time.time * (i + 1), 0) * Vector3.forward * orbitRadius;

            planet.position = orbitPos;
            planet.Rotate(Vector3.up, rotationSpeed * orbitSpeed * Time.deltaTime); // planets have a certain number of days per orbit
        }
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoxCollider"))
        {
            isInteracted = true;
            Invoke(nameof(ReturnToOriginalOrbit), 5f); // Delayed return after 5 seconds
        }
    }

    void ReturnToOriginalOrbit()
    {
        isInteracted = false;
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform planet = transform.GetChild(i);

            // Lerp back to the original positions in the orbit
            planet.position = Vector3.Lerp(planet.position, originalPositions[i], Time.deltaTime * 2f);
            planet.rotation = Quaternion.Lerp(planet.rotation, originalRotations[i], Time.deltaTime * 2f);
        }
    }*/
}
