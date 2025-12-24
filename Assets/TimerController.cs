using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int targetHours = 0; // Set target time in hours
    public int targetMinutes = 10; // Set target time in minutes
    public int targetSeconds = 0; // Set target time in seconds
    private float currentTime; // Tracks the current timer value
    private bool timerActive = false;
    public TMP_Text timerText;
    public delegate void TimerFinished();
    public event TimerFinished OnTimerFinishedEvent;
    public bool showHours = true; // Toggle to show or hide hours
    public bool showMinutes = true; // Toggle to show or hide minutes

    void Start()
    {
        // Subscribe the TimerFinishedCallback method to the event
        OnTimerFinishedEvent += TimerFinishedCallback;
    }

    public void StartTimer()
    {
        currentTime = targetHours * 3600 + targetMinutes * 60 + targetSeconds;
        timerActive = true;
        Debug.Log("Timer started!");
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
                timerActive = false;
                TriggerTimerFinishedEvent();
            }
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        int hours = Mathf.FloorToInt(currentTime / 3600);
        int minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        if (showHours && showMinutes)
        {
            timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
        else if (showHours)
        {
            timerText.text = string.Format("{0:D2}:{1:D2}", hours, seconds);
        }
        else if (showMinutes)
        {
            timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
        else
        {
            timerText.text = string.Format("{0:D2}", seconds);
        }
    }

    private void TriggerTimerFinishedEvent()
    {
        Debug.Log("Timer ended!");
        OnTimerFinishedEvent?.Invoke(); // Invoke the event
    }

    private void TimerFinishedCallback()
    {
        Debug.Log("Timer finished! Executing callback...");
        // Add your callback here
    }
}

