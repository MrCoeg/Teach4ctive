using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreboardDetailedInstance : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI score;
    public GameObject scoreMarkerPrefab;
    public Transform parent;

    public TextMeshProUGUI timeText;



    public Image teamAColor;
    public Image teamBColor;


    public TextMeshProUGUI scoreMarkerName;
    public TextMeshProUGUI scoreMarkerTeam;
    ScoreboardEntry scoreboard;
    TimerEntry timer;
    Dictionary<string, Color> textColor;

    private void Start()
    {


        scoreboard = SingletonManager.Instance.scoreboard.GetDataById(SingletonManager.Instance.currentDetailedScoreboardId);
        timer = SingletonManager.Instance.timerGroup.GetDataById(scoreboard.TimerId);

        textColor = new Dictionary<string, Color> {
            { scoreboard.TeamAName, scoreboard.TeamAColor},  { scoreboard.TeamBName, scoreboard.TeamBColor}

        };





        StartCoroutine(SingletonManager.Instance.runTimer(timer, timeText));

        title.text = scoreboard.TeamAName + " VS " + scoreboard.TeamBName;
        score.text = scoreboard.TeamAScore + " : " + scoreboard.TeamBScore;

        teamAColor.color = scoreboard.TeamAColor;
        teamBColor.color = scoreboard.TeamBColor;


        for (int i = 0; i < scoreboard.ScoreMakerName.items.Count; i++)
        {
            var instantiated = Instantiate(scoreMarkerPrefab, parent, false);
            var details = instantiated.GetComponentsInChildren<TextMeshProUGUI>();

            details[1].text = scoreboard.ScoreMakerName.items[i];

            details[0].text = scoreboard.ScoreMakerTeamName.items[i];
            details[0].color = textColor[scoreboard.ScoreMakerTeamName.items[i]];
        }
    }

    public void AddScoreMaker()
    {

            var instantiated = Instantiate(scoreMarkerPrefab, parent, false);
            var details = instantiated.GetComponentsInChildren<TextMeshProUGUI>();

            details[1].text = scoreboard.ScoreMakerName.items[0];

            details[0].text = scoreboard.ScoreMakerTeamName.items[0];
            details[0].color = textColor[scoreboard.ScoreMakerTeamName.items[0]];
        
    }
}
