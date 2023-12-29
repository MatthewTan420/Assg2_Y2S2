using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerLb1;
    public float timer;

    /// <summary>
    /// Starts timer, stops game when it hits 0
    /// </summary>
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            DisplayTime(timer);
        }
        else
        {
            timerLb1.text = "0:0";
        }
    }

    /// <summary>
    /// Display time
    /// </summary>
    private void DisplayTime(float displayTime)
    {
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        timerLb1.text = $"{minutes}:{seconds}";
    }
}
