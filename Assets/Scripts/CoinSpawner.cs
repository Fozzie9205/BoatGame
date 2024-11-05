using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int minInclusiveX;
    public int maxExclusiveX;
    public int minInclusiveZ;
    public int maxExclusiveZ;

    private bool coinSpawning;

    void Start()
    {
        coinSpawning = false;
    }
    private void Update()
    {
        StartCoroutine(Coroutine());
    }
    IEnumerator Coroutine()
    {
        if (!coinSpawning)
        {
            coinSpawning = true;
            yield return new WaitForSeconds(3);
            GameObject coin = ObjectPool_Coin.SharedInstance.GetPooledObject();
            if (coin != null)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(minInclusiveX, maxExclusiveX), 1, Random.Range(minInclusiveZ, maxExclusiveZ));
                coin.transform.position = randomSpawnPosition;
                coin.SetActive(true);
            }
            coinSpawning = false;
        }
    }
}
