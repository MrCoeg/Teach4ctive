using UnityEngine;

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

