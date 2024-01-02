using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Instance { get; private set; }

    public Credentials credentials;
    public StopwatchGroup stopwatchGroup;
    public StopwatchDetailed stopwatchDetailed;
    public TimerGroup timerGroup;
    public Scoreboard scoreboard;
    public DesignKu designKu;
    public UiObject uiObject;
    public Pustaka pustaka;
    public Tournamen tournament;

    public int currentStopwatchGroupId;
    public int currentDesignGroupId;
    public int currentTurnamenGroupId;
    public int currentDetailedScoreboardId;
    public Page currentPage = new Page();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator runTimer(TimerEntry entry, TMPro.TextMeshProUGUI text)
    {
        TimerEntry newEntry = timerGroup.GetDataById(entry.Id) ;
        while (newEntry.IsRunning)
        {

            newEntry = timerGroup.GetDataById(entry.Id);

            entry.CurrentTime -= 1f;
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(entry.CurrentTime);
            text.text = string.Format("{0:D2} : {1:D2} : {2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            timerGroup.UpdateTimeById(entry.Id, entry.CurrentTime);
            
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}

public enum ScriptableObjectTypes
{
    Person,
    StopwatchGroup,
    StopwatchDetailed
}

public enum CredentialsProperties
{
    Id,
    Fullname,
    Gender,
    Birthdate,
    HandphoneNumber,
    Province,
    City,
    Email,
    Password
}

public enum StopwatchGroupProperties
{
    Id,
    UserId,
    Title,
    Count
}

public enum StopwatchDetailedProperties
{
    Id,
    StopwatchGroupId,
    Title,
    CurrentStopwatchTime,
    MaxTime,
    IsPaused,
    IsRunning,
    IsStop
}

