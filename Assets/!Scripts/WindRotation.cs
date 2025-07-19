using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRotation : MonoBehaviour
{
    public WindZone windZone;
    public float rotationSpeed = 2.0f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
