using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "TimerData", menuName = "ScriptableObjects/TimerData")]
public class TimerGroup : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<int> scoreboardId = new List<int>();
    public List<string> title = new List<string>();
    public List<float> timerTime = new List<float>(); // Total time for each timer
    public List<float> currentTime = new List<float>(); // Current time on each timer
    public List<bool> isPaused = new List<bool>();
    public List<bool> isRunning = new List<bool>();
    public List<bool> isStop = new List<bool>();


    public void Insert(TimerEntry entry)
    {
        id.Add(entry.Id);
        scoreboardId.Add(entry.ScoreboardId);
        title.Add(entry.Title);
        timerTime.Add(entry.TimerTime); // Total time for each timer
        currentTime.Add(entry.CurrentTime); // Current time on each timer
        isPaused.Add(entry.IsPaused);
        isRunning.Add(entry.IsStop);
        isStop.Add(entry.IsStop);
    }

    public List<TimerEntry> GetAllData()
    {
        List<TimerEntry> allData = new List<TimerEntry>();
        for (int i = 0; i < id.Count; i++)
        {
            allData.Add(new TimerEntry
            {
                Id = id[i],
                ScoreboardId = scoreboardId[i],
                Title = title[i],
                TimerTime = timerTime[i],
                CurrentTime = currentTime[i],
                IsPaused = isPaused[i],
                IsRunning = isRunning[i],
                IsStop = isStop[i]
            });
        }
        return allData;
    }

    // Method to get data by ID
    public TimerEntry GetDataById(int timerId)
    {
        int index = id.IndexOf(timerId);
        if (index != -1)
        {
            return new TimerEntry
            {
                Id = id[index],
                ScoreboardId = scoreboardId[index],
                Title = title[index],
                TimerTime = timerTime[index],
                CurrentTime = currentTime[index],
                IsPaused = isPaused[index],
                IsRunning = isRunning[index],
                IsStop = isStop[index]
            };
        }
        throw new System.Exception("Timer with specified ID not found");
    }

    public void UpdateTimeById(int id, float time)
    {
        int index = this.id.IndexOf(id);
        if (index != -1)
        {
            currentTime[index] = time;
        }
    }

    public void UpdateStatusById(int id, TimerStatus status)
    {
        int index = this.id.IndexOf(id);
        if (index != -1)
        {
            switch (status)
            {
                case TimerStatus.running:
                    isRunning[index] = true;
                    isStop[index] = false;
                    isPaused[index] = false;
                    break;
                case TimerStatus.paused:
                    isRunning[index] = false;
                    isStop[index] = false;
                    isPaused[index] = true;
                    break;
                case TimerStatus.stopped:
                    isRunning[index] = false;
                    isStop[index] = true;
                    isPaused[index] = false;
                    break;
                default:
                    break;
            }
        }

    }

    // Method to get data by Scoreboard ID
    public List<TimerEntry> GetDataByScoreboardId(int boardId)
    {
        return GetAllData().Where(entry => entry.ScoreboardId == boardId).ToList();
    }
}

public enum TimerStatus
{
    running, paused, stopped
}
public struct TimerEntry
{
    public int Id;
    public int ScoreboardId;
    public string Title;
    public float TimerTime;
    public float CurrentTime;
    public bool IsPaused;
    public bool IsRunning;
    public bool IsStop;
}
