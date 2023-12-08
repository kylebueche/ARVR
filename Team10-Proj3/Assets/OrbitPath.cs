using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPath : MonoBehaviour
{
    public Transform sun;
    public float orbitRadiusScale = 1.0f;
    public float orbitSpeedScale = 1.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform planet = transform;
        // Calculate the orbit distance (radius) based on the object's position relative to the center
        float orbitRadius = Vector3.Distance(sun.position, planet.position);

        // Get the orbit speed, and rotation speed from values attached to the individual orbiting planets
        PlanetProperties planetProperties = planet.GetComponent<PlanetProperties>();
        float orbitSpeed = (planetProperties ? planetProperties.orbitSpeed : 0.0f) * orbitSpeedScale;
        float rotationSpeed = (planetProperties ? planetProperties.rotationSpeed : 0.0f);

        // Calculate the orbit position based on time and planet parameters
        Vector3 orbitPos = sun.position + Quaternion.Euler(0, orbitSpeed * Time.time, 0) * Vector3.forward * orbitRadius;

        planet.position = orbitPos;
        planet.Rotate(Vector3.up, rotationSpeed * orbitSpeed * Time.deltaTime); // planets have a certain number of days per orbit
    }
}
