using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private static float timeRemaining = 30;

    private void Start()
    {
        if (Energy.data.energy >= 50) return;
        var timeAway = DateTime.Now - Energy.data.quitGame;
        var seconds = timeAway.Seconds + timeAway.Minutes * 60 + timeAway.Hours * 3600;
        var energyAdd = Mathf.FloorToInt(seconds / 30) * 5;
        if (Energy.data.energy + energyAdd > 50)
        {
            Energy.data.energy = 50;
        }
        else
        {
            Energy.data.energy += energyAdd;
        }

        timeRemaining -= Mathf.FloorToInt(seconds % 30);
    }

    private void Update()
    {
        GetComponent<Text>().text = "Energy: " + Energy.data.energy;
        if (Energy.data.energy >= 50)
        {
            timerText.text = "00:00";
            return;
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Display(timeRemaining);
        }
        else
        {
            Energy.data.energy += 5;
            if (Energy.data.energy == 50) return;
            timeRemaining = 30;
        }
    }

    private void Display(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnApplicationQuit()
    {
        var newData = SaveSystem.LoadPlayer();
        newData.quitGame = DateTime.Now;
        newData.energy = Energy.data.energy;
        SaveSystem.SavePlayer(newData);
    }
}