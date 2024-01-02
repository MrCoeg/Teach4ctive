using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "ScoreboardData", menuName = "Sports/ScoreboardData")]
public class Scoreboard : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<int> tournamentId = new List<int>();
    public List<int> timerId = new List<int>();
    public List<int> totalMatch = new List<int>();
    public List<float> additionalTime = new List<float>();
    public List<string> teamAName = new List<string>();
    public List<string> teamBName = new List<string>();
    public List<int> teamAScore = new List<int>();
    public List<int> teamBScore = new List<int>();
    public List<Color> teamAColor = new List<Color>();
    public List<Color> teamBColor = new List<Color>();
    public List<StringList> scoreMakerTeamName = new List<StringList>();
    public List<StringList> scoreMakerName = new List<StringList>();

    // Method to get all data
    public List<ScoreboardEntry> GetAllData()
    {
        List<ScoreboardEntry> allData = new List<ScoreboardEntry>();
        for (int i = 0; i < id.Count; i++)
        {
            Debug.Log(i);
            allData.Add(new ScoreboardEntry
            {
                Id = id[i],
                TournamentId = tournamentId[i],
                TimerId = timerId[i],
                TotalMatch = totalMatch[i],
                AdditionalTime = additionalTime[i],
                TeamAName = teamAName[i],
                TeamBName = teamBName[i],
                TeamAScore = teamAScore[i],
                TeamBScore = teamBScore[i],
                TeamAColor = teamAColor[i],
                TeamBColor = teamBColor[i],
                ScoreMakerTeamName = scoreMakerTeamName[i],
                ScoreMakerName = scoreMakerName[i]
            });
        }
        return allData;
    }

    // Method to get data by ID

    public void Insert(ScoreboardEntry entry)
    {

        id.Add(entry.Id);
        tournamentId.Add(entry.TournamentId);
        timerId.Add(entry.TimerId);
        totalMatch.Add(entry.TotalMatch);
        additionalTime.Add(entry.AdditionalTime);
        teamAName.Add(entry.TeamAName);
        teamBName.Add(entry.TeamBName);
        teamAScore.Add(entry.TeamAScore);
        teamBScore.Add(entry.TeamBScore);
        teamAColor.Add(entry.TeamAColor);
        teamBColor.Add(entry.TeamBColor);
        scoreMakerTeamName.Add(entry.ScoreMakerTeamName);
        scoreMakerName.Add(entry.ScoreMakerName);

        
}
    public ScoreboardEntry GetDataById(int scoreboardId)
    {
        int index = id.IndexOf(scoreboardId);
        if (index != -1)
        {
            return new ScoreboardEntry
            {
                Id = id[index],
                TournamentId = tournamentId[index],
                TimerId = timerId[index],
                TotalMatch = totalMatch[index],
                AdditionalTime = additionalTime[index],
                TeamAName = teamAName[index],
                TeamBName = teamBName[index],
                TeamAScore = teamAScore[index],
                TeamBScore = teamBScore[index],
                TeamAColor = teamAColor[index],
                TeamBColor = teamBColor[index],
                ScoreMakerTeamName = scoreMakerTeamName[index],
                ScoreMakerName = scoreMakerName[index]
            };
        }
        throw new System.Exception("Scoreboard with specified ID not found");
    }

    // Method to get data by Tournament ID
    public List<ScoreboardEntry> GetDataByTournamentId(int tournamentId)
    {
        return GetAllData().Where(entry => entry.TournamentId == tournamentId).ToList();
    }

    // Method to update data by ID
    public void UpdateDataById(int scoreboardId, ScoreboardEntry updatedEntry)
    {
        int index = id.IndexOf(scoreboardId);
        if (index != -1)
        {
            // Update each list at the index with data from updatedEntry
        }
        else
        {
            throw new System.Exception("Scoreboard with specified ID not found for update");
        }
    }

    public void UpdateScoreMakerById(int scoreboardId, string name, string teamName)
    {
        int index = id.IndexOf(scoreboardId);
        if (index != -1)
        {
            // Update each list at the index with data from updatedEntry
        }
        else
        {
            throw new System.Exception("Scoreboard with specified ID not found for update");
        }
    }
}

public struct ScoreboardEntry
{
    public int Id;
    public int TournamentId;
    public int TimerId;
    public int TotalMatch;
    public float AdditionalTime;
    public string TeamAName;
    public string TeamBName;
    public int TeamAScore;
    public int TeamBScore;
    public Color TeamAColor;
    public Color TeamBColor;
    public StringList ScoreMakerTeamName;
    public StringList ScoreMakerName;
}

public struct ScoreboardInstanceEntry
{
    public string TeamAName;
    public string TeamBName;
    public int TeamAScore;
    public int TeamBScore;
    public Color TeamAColor;
    public Color TeamBColor;
}

[System.Serializable]
public class StringList
{
    public List<string> items = new List<string>();
}
