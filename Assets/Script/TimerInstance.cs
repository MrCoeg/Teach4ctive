using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerInstance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpPro1;
    [SerializeField] private TextMeshProUGUI tmpPro2;
    public Button playButton, pauseButton, stopButton;
    [SerializeField] TimerEntry entry;
    [SerializeField] private int id;
    private float elapsedTime;

    // Initialization method
    public void Init(TimerEntry entry)
    {

        if (id >= 0)
        {
            this.entry = entry;

            playButton.onClick.AddListener(StartTimer);
            pauseButton.onClick.AddListener(PauseTimer);
            stopButton.onClick.AddListener(ResetTimer);
        }

        elapsedTime = this.entry.CurrentTime;

        if (entry.IsRunning)
        {
            StartTimer();
        }

        if (tmpPro1 != null)
            tmpPro1.text = entry.Title;

        if (tmpPro2 != null)
        {
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(entry.CurrentTime);
            tmpPro2.text = string.Format("{0:D2} : {1:D2} : {2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        }

        elapsedTime = entry.CurrentTime;
    }
    private void Update()
    {
        if (entry.IsRunning)
        {
            entry.IsRunning = false;
            StartCoroutine(SingletonManager.Instance.runTimer(SingletonManager.Instance.timerGroup.GetDataById(entry.Id), tmpPro2));
/*
            elapsedTime -= Time.deltaTime;
            SingletonManager.Instance.timerGroup.UpdateTimeById(entry.Id, elapsedTime);
            UpdateStopwatchText();*/
        }


    }

    private void UpdateStopwatchText()
    {
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(elapsedTime);
        tmpPro2.text = string.Format("{0:D2} : {1:D2} : {2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }

    private void StartTimer()
    {
        SingletonManager.Instance.timerGroup.UpdateStatusById(entry.Id, TimerStatus.running);
        entry.IsRunning = true;
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        stopButton.gameObject.SetActive(true);
    }

    private void PauseTimer()
    {
        SingletonManager.Instance.timerGroup.UpdateStatusById(entry.Id, TimerStatus.paused);
        entry.IsRunning = false;
        entry.IsPaused = true;
        pauseButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    private void ResetTimer()
    {
        SingletonManager.Instance.timerGroup.UpdateStatusById(entry.Id, TimerStatus.stopped);
        entry.IsRunning = false;
        entry.IsStop = true;
        elapsedTime = entry.TimerTime;
        /*        UpdateStopwatchText();*/
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(false);
    }
}
