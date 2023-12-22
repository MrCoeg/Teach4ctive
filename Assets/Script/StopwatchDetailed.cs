using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "NewStopwatchDetailed", menuName = "ScriptableObjects/StopwatchDetailed", order = 1)]
public class StopwatchDetailed : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<int> stopwatchGroupId = new List<int>();
    public List<string> title = new List<string>();
    public List<float> currentStopwatchTime = new List<float>(); // Time in seconds
    public List<float> maxTime = new List<float>(); // Max time in seconds
    public List<bool> isPaused = new List<bool>();
    public List<bool> isRunning = new List<bool>();
    public List<bool> isStop = new List<bool>();
}
