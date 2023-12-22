using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Globalization;

public class FormTambahScoreboard : MonoBehaviour
{
    public List<FormInputField> teams = new List<FormInputField>();
    public ToggleGroup matchNumber;
    public Toggle activeToggle;
    public TMP_Dropdown dropdown;
    public string text;

    public DragableNumber[] timer;

    public Color[] colors;
    public int teamAColorId;
    public int teamBColorId;

    public Button teamAbutton;
    public Button teamBbutton;



    public Button button;
    public Button buttonBack;

    public GameObject prefab;
    public Transform parent;
    public int sceneindex;

    private void Awake()
    {
        button.onClick.AddListener(OnSubmit);
        buttonBack.onClick.AddListener(() =>
        {
            StaticSceneChanger.ChangeScene(sceneindex);
        });

        // Ensure the dropdown is assigned
        if (dropdown != null)
        {
            // Add listener for when the value of the TMP Dropdown changes
            dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);
        }
    }

    private void HandleDropdownValueChanged(int value)
    {
        // Handle the new value here
        text = dropdown.options[value].text;
    }

    public void onActiveToggle()
    {
        activeToggle = matchNumber.ActiveToggles().FirstOrDefault();
    }

    public void TeamAColor()
    {
        teamAColorId += 1;
        if (teamAColorId >= colors.Length)
        {
            teamAColorId = 0;
        }

        teamAbutton.GetComponent<Image>().color = colors[teamAColorId];
    }

    public void TeamBColor()
    {
        teamBColorId += 1;
        if (teamBColorId >= colors.Length)
        {
            teamBColorId = 0;
        }

        teamBbutton.GetComponent<Image>().color = colors[teamBColorId];
    }

    public void OnSubmit()
    {
        List<string> stringList = teams.Select(script => script.TMP_text.text).ToList();
        var time = (timer[0].value * 3600) + (timer[1].value * 60) + timer[2].value;
        var addtime = float.Parse(text.Split(' ')[0], CultureInfo.InvariantCulture.NumberFormat);
        SingletonManager.Instance.timerGroup.Insert(new TimerEntry
        {
            Id = SingletonManager.Instance.timerGroup.id.Count,
            ScoreboardId = SingletonManager.Instance.scoreboard.id.Count,
            Title = "Match",
            TimerTime = time + addtime,
            CurrentTime = time + addtime,
            IsPaused = false,
            IsRunning = false,
            IsStop = false,
        });

        SingletonManager.Instance.scoreboard.Insert(new ScoreboardEntry
        {
            Id = SingletonManager.Instance.scoreboard.id.Count,
            TeamAName = stringList[0],
            TeamBName = stringList[1],
            TeamAColor = colors[teamAColorId],
            TeamBColor = colors[teamBColorId],
            TournamentId = -1,
            AdditionalTime = addtime,
        });

        StaticSceneChanger.ChangeScene(sceneindex);

    }
}
