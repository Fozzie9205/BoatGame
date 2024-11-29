using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject redFlash;

    public float health;
    public float damage;
    public float waitTime;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        health -= damage;

        if (health > 0)
        {
            redFlash.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            redFlash.SetActive(false);
        }

        if (health <= 0)
        {
            redFlash.SetActive(true);
            deathScreen.SetActive(true);
        }
    }
}
