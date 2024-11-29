using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public PlayerCoins playerCoins;

    public float score;
    public TMP_Text scoreText;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void Save()
    {
        score = playerCoins.coins;
        if (score >= PlayerPrefs.GetFloat("Score", 0))
        {
            PlayerPrefs.SetFloat("Score", score);
        }

        SetScore();
    }

    void SetScore()
    {
        scoreText.text = "High Score: " + PlayerPrefs.GetFloat("Score").ToString();
    }
}
