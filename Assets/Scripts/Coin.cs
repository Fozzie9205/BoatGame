using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
