using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothWind : MonoBehaviour
{
    public WindRotation windRotation;
    public Cloth cloth;

    public float windStrength = 1.0f;
    void Start()
    {
        cloth = GetComponent<Cloth>();   
    }
    void Update()
    {
        // Get the wind direction from the WindZone's rotation
        Vector3 windDirection = windRotation.windZone.transform.forward;

        // Optionally, scale by windZone's intensity if applicable
        float windIntensity = windRotation.windZone.windMain; // Adjust based on your WindZone settings
        Vector3 scaledWind = windDirection * windIntensity * windStrength;

        // Apply to the cloth's external acceleration
        cloth.externalAcceleration = scaledWind;
    }
}
