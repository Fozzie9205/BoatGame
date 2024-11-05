using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerCoins : MonoBehaviour
{
    public TMP_Text coinText;
    private float coins = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        coins++;
        coinText.text = "Coins: " + coins;
    }
}
