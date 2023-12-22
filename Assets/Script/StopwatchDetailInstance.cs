using UnityEngine;
using TMPro;
using System;

public class StopwatchDetailInstance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleTMP;
    [SerializeField] private TextMeshProUGUI timeTMP;

    // Initialization method
    public void Init(string title, float maxTime)
    {
        if (titleTMP != null)
            titleTMP.text = title;

        if (timeTMP != null)
            timeTMP.text = FormatTime(maxTime);
    }

    // Helper method to format time in "00:00:00" format
    private string FormatTime(float timeInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);
        return time.ToString(@"hh\:mm\:ss");
    }
}
