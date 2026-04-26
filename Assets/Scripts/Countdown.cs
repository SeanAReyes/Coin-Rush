using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float remainingTime;
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    { 
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            gameManager.GameOver();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
}
