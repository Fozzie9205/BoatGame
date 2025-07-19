using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SaveScore saveScore;
    public GameObject deathScreen;
    public GameObject redFlash;

    public float health;
    public float damage;
    public float waitTime;

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
            Death();
        }
    }
    
    void Death()
    {
        saveScore.Save();
        redFlash.SetActive(true);
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
