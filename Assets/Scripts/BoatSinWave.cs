using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSinWave : MonoBehaviour
{
    public float floatSpeed;
    public float sinVal;
    public float height;

    private float nextPosition;
    void Start()
    {
        
    }

    void Update()
    {
        sinVal += Mathf.PI * floatSpeed * Time.unscaledDeltaTime;
        nextPosition = height * Mathf.Sin(sinVal);
        transform.Translate(Vector3.up * nextPosition);
    }
}
