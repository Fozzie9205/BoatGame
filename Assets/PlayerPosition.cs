using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPosition : MonoBehaviour
{
    public Transform player;
    public TMP_Text text; 
    void Update()
    {
        text.text = (player.position).ToString();
    }
}
