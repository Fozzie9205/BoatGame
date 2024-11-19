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
        if (Mathf.Approximately(Time.timeScale, 0.0f))
        {
            return;
        }
        sinVal += Mathf.PI * floatSpeed * Time.deltaTime;
        nextPosition = height * Mathf.Sin(sinVal);
        transform.Translate(Vector3.up * nextPosition);
    }
}
