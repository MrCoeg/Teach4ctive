
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Globalization;


public class FormTambahTurnamen : MonoBehaviour
{
    public List<FormInputField> teams = new List<FormInputField>();
    public List<Button> teams_color = new List<Button>();
    public List<int> teamsColorId = new List<int>();

    public Transform teamsParent;

    public ToggleGroup matchNumber;
    public ToggleGroup matchType;

    public Toggle activeToggle;
    public Toggle matchTypeToggle;


    public TMP_Dropdown dropdown;
    public string text;
    public string matchText;

    public DragableNumber[] timer;

    public Color[] colors;
    public int teamAColorId;
    public int teamBColorId;

    public Button button;
    public Button buttonBack;

    public GameObject prefab;
    public Transform parent;
    public int sceneindex;

    public GameObject panel;
    public GameObject scoreboardPrefab;
    public Transform scoreboardParent;

    private List<GameObject> toRemove;
    List<ScoreboardEntry> entry;

    private TournamentMode mode;
    private void Awake()
    {
        button.onClick.AddListener(OnSubmit);
        buttonBack.onClick.AddListener(() =>
        {

            panel.SetActive(false);
            for (int i = 0; i < toRemove.Count; i++)
            {
                DestroyImmediate(toRemove[i]);
            }
        });

        // Ensure the dropdown is assigned
        if (dropdown != null)
        {
            text = dropdown.options[0].text;
            // Add listener for when the value of the TMP Dropdown changes
            dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);
        }

        for (int i = 0; i < teams_color.Count; i++)
        {
            var counter = i;
            Debug.Log(i);
            teams_color[i].onClick.AddListener(() =>
            {
                Debug.Log(counter + "SD");
                TeamsColor(counter);
            });
        }
    }


    public void AddTeams()
    {
        var instantiated = StaticUIInstantiator.InstantiateUIAtSecondLast(teams[teams.Count-1].gameObject, teamsParent, teams.Count);

        var buttons = instantiated.GetComponentsInChildren<Button>();
        buttons[buttons.Length-1].onClick.AddListener(() => {
            TeamsColor(teams_color.Count-1);
        });

        teams.Add(instantiated.GetComponent<FormInputField>());
        teams_color.Add(buttons[buttons.Length-1]);
        teamsColorId.Add(0);
    }

    public void TeamsColor(int teamIndex)
    {
        Debug.Log(teamIndex + " " + teamsColorId.Count + " ");
        teamsColorId[teamIndex] += 1;
        if (teamsColorId[teamIndex] >= colors.Length)
        {
            teamsColorId[teamIndex] = 0;
        }

        teams_color[teamIndex].GetComponent<Image>().color = colors[teamsColorId[teamIndex]];
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

    public void onActiveMatchToggle()
    {
        matchTypeToggle = matchType.ActiveToggles().FirstOrDefault();
    }

    public void ViewMatch()
    {

        Debug.Log(matchTypeToggle.name == "Single" + " " + matchTypeToggle.name);
        if (matchTypeToggle.name == "Single")
        {
            mode = TournamentMode.SingleRoundRobin;
            entry = SingletonManager.Instance.tournament.GenerateSingleRoundRobin(new TeamInformation { 
                name = teams.Select(script => script.TMP_text.text).ToList(),
                color = teams_color.Select(script => script.GetComponent<Image>().color).ToList(),
            });

        }
        else
        {
            mode = TournamentMode.DoubleRoundRobin;

            entry = SingletonManager.Instance.tournament.GenerateDoubleRoundRobin(new TeamInformation
            {
                name = teams.Select(script => script.TMP_text.text).ToList(),
                color = teams_color.Select(script => script.GetComponent<Image>().color).ToList(),
            });
        }

        var instantiated = StaticUIInstantiator.InstantiateScoreboard(entry.Count, scoreboardPrefab, scoreboardParent);
        toRemove = instantiated;
        var timerInstance = instantiated.Select(script => script.GetComponent<ScoreboardInstance>()).ToList();

        for (int i = 0; i < instantiated.Count; i++)
        {
            timerInstance[i].Init(entry[i]);
        }

        panel.SetActive(true);
    }

    public void OnSubmit()
    {
        List<string> stringList = teams.Select(script => script.TMP_text.text).ToList();
        var time = (timer[0].value * 3600) + (timer[1].value * 60) + timer[2].value;
        var addtime = float.Parse(text.Split(' ')[0], CultureInfo.InvariantCulture.NumberFormat);



        SingletonManager.Instance.tournament.AddTournamen(new TournamentEntry 
        { 
            Id = SingletonManager.Instance.tournament.id.Count,
            Time = time,
            AdditionalTime = addtime,
            Mode = mode,
            Teams = new TeamInformation
            {
                name = teams.Select(script => script.TMP_text.text).ToList(),
                color = teams_color.Select(script => script.GetComponent<Image>().color).ToList(),
            },
            Title = "Tournament",
            TotalMatch = int.Parse(activeToggle.name),
        });

        StaticSceneChanger.ChangeScene(sceneindex);

    }
}
