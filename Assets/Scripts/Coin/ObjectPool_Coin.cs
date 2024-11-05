using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Coin : MonoBehaviour
{
    public static ObjectPool_Coin SharedInstance;
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
        GameObject coin;
        for (int i=0; i < amountToPool; i++)
        {
            coin = Instantiate(objectToPool);
            coin.SetActive(false);
            pooledObjects.Add(coin);
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
