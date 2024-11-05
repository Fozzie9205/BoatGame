using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    private Vector3 startCoordinates;
    private Vector3 endCoordinates;
    public float speed = 0.3f;
    private Vector3 currentTarget;
    void Start()
    {
        startCoordinates = gameObject.transform.position;
        endCoordinates = new Vector3(startCoordinates.x, startCoordinates.y + 0.5f, startCoordinates.z);
        currentTarget = endCoordinates;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            if (currentTarget == endCoordinates)
            {
                currentTarget = startCoordinates;
            }
            else
            {
                currentTarget = endCoordinates;
            }
        }
    }
}
