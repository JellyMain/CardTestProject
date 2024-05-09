using System;
using UnityEngine;
using TMPro;


public class GameTimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float maxTime;
    private float currentTime;
    private bool stopTimer;
    
    public static event Action TimerIsUp;

    
    private void Start()
    {
        currentTime = maxTime;
        UpdateUI();
    }
    


    private void Update()
    {
        CountdownTimer();
    }


    private void CountdownTimer()
    {
        if (currentTime > 0 && !stopTimer)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            TimerIsUp?.Invoke();
            stopTimer = false;
        }
    }


    private void StopTimer()
    {
        stopTimer = true;
    }


    private void UpdateUI()
    {
        timerText.text = currentTime.ToString("F1");
    }
}
