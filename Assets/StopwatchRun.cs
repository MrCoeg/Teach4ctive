using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class StopwatchRun : MonoBehaviour
{
    public Button playButton, pauseButton, stopButton, saveButton, backButton;
    public Transform parent;
    public StopwatchSO so;
    public TextMeshProUGUI stopwatchText;

    private float elapsedTime;
    private bool isRunning;

    private void Start()
    {
        ResetStopwatch();
        playButton.onClick.AddListener(StartStopwatch);
        pauseButton.onClick.AddListener(PauseStopwatch);
        stopButton.onClick.AddListener(ResetStopwatch);
        saveButton.onClick.AddListener(Save);
        backButton.onClick.AddListener(Back);
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateStopwatchText();
        }
    }

    private void Back()
    {
        this.gameObject.SetActive(false);
    }

    private void Save()
    {
        var sid = parent.GetComponentInChildren<StopwatchID>();
        so.stopwatchName.Add("OK");
        so.time.Add(elapsedTime);
        if (so.id.Count == 0)
        {
            so.id.Add(0);
            sid.AddRecord(0);
            

        }
        else
        {
            so.id.Add(so.id.Count-1);
            sid.AddRecord(so.id.Count - 1);

        }

        ResetStopwatch();
        this.gameObject.SetActive(false);
    }

    private void StartStopwatch()
    {
        isRunning = true;
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        stopButton.gameObject.SetActive(true);
    }

    private void PauseStopwatch()
    {
        isRunning = false;
        pauseButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    private void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0;
        UpdateStopwatchText();
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(false);
    }

    private void UpdateStopwatchText()
    {
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(elapsedTime);
        stopwatchText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
}
