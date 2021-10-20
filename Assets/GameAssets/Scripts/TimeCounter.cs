using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI gameTimerText;
    float gameTimer = 0f;
    void Update()
    {
        gameTimer += Time.deltaTime;

        int seconds = (int)(gameTimer%60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer/3600) % 24;

        string timerString = string.Format("{0:00}:{1:00}:{2:00}",hours,minutes,seconds);

        gameTimerText.text = timerString;
    }
}
