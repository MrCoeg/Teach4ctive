using UnityEngine;
using System.Collections.Generic;
using System.Linq;
[CreateAssetMenu(fileName = "NewStopwatchGroup", menuName = "ScriptableObjects/StopwatchGroup", order = 1)]
public class StopwatchGroup : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<int> userId = new List<int>();
    public List<string> title = new List<string>();
    public List<int> count;

    // Function to get all data
    public List<(int, int, string)> GetAllData()
    {
        List<(int, int, string)> allData = new List<(int, int, string)>();
        for (int i = 0; i < id.Count; i++)
        {
            allData.Add((id[i], userId[i], title[i]));
        }
        return allData;
    }

    // Function to get an item by index
    public (int, int, string) GetItemByIndex(int index)
    {
        if (index >= 0 && index < id.Count)
        {
            return (id[index], userId[index], title[index]);
        }
        throw new System.IndexOutOfRangeException("Index out of range");
    }

    // Function to get an item by ID
    public (int, int, string) GetItemById(int itemId)
    {
        int index = id.IndexOf(itemId);
        if (index != -1)
        {
            return GetItemByIndex(index);
        }
        throw new System.Exception("Item with specified ID not found");
    }

    public (bool, string) AddStopwatchGroup(StopwatchGroupDetail detail)
    {
        if (detail.Title == "")
        {
            return (false, "Please fill stopwatch name");
        }

        id.Add(detail.Id);
        userId.Add(detail.UserId);
        this.title.Add(detail.Title);
        count.Add(detail.Count);

        return (true, "Success");
    }

    public List<StopwatchDetail> FindDetailsByGroupId(int groupId)
    {
        List<StopwatchDetail> details = new List<StopwatchDetail>();
        StopwatchDetailed detailed = SingletonManager.Instance.stopwatchDetailed;

        for (int i = 0; i < detailed.stopwatchGroupId.Count; i++)
        {
            if (detailed.stopwatchGroupId[i] == groupId)
            {
                StopwatchDetail detail = new StopwatchDetail
                {
                    Id = detailed.id[i],
                    Title = detailed.title[i],
                    CurrentTime = detailed.currentStopwatchTime[i],
                    MaxTime = detailed.maxTime[i],
                    IsPaused = detailed.isPaused[i],
                    IsRunning = detailed.isRunning[i],
                    IsStopped = detailed.isStop[i]
                };
                details.Add(detail);
            }
        }

        return details.OrderBy(d => d.MaxTime).ToList();
    }
}
public struct StopwatchDetail
{
    public int Id;
    public string Title;
    public float CurrentTime;
    public float MaxTime;
    public bool IsPaused;
    public bool IsRunning;
    public bool IsStopped;
}

public struct StopwatchGroupDetail
{
    public int Id;
    public string Title;
    public int UserId ;
    public int Count;
}