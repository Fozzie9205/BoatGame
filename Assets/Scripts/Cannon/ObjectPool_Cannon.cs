using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Cannon : MonoBehaviour
{
    public static ObjectPool_Cannon SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject cannonBall;
        for (int i = 0; i < amountToPool; i++)
        {
            cannonBall = Instantiate(objectToPool);
            cannonBall.SetActive(false);
            pooledObjects.Add(cannonBall);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
