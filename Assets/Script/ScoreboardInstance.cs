using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreboardInstance : MonoBehaviour
{
    public TextMeshProUGUI teamAname;
    public TextMeshProUGUI teamBname;

    public TextMeshProUGUI score;

    public Image teamAcolor;
    public Image teamBcolor;

    public int id;
    public void Init(ScoreboardEntry entry)
    {
        id = entry.Id;
        teamAname.text = entry.TeamAName;
        teamBname.text = entry.TeamBName;

        score.text = entry.TeamAScore.ToString() + " : " + entry.TeamBScore.ToString();

        teamAcolor.color = entry.TeamAColor;
        teamBcolor.color = entry.TeamBColor;


    }

}
