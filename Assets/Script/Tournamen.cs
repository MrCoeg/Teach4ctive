using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tournament", menuName = "Tournament/TournamentData")]
public class Tournamen : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<string> title = new List<string>();
    public List<TeamInformation> teams;
    public List<float> time = new List<float>();
    public List<int> totalMatch = new List<int>();
    public List<float> additionalTime = new List<float>();
    public List<TournamentMode> mode = new List<TournamentMode>();

    private List<ScoreboardEntry> currentScoreboardEntryTemp;

    public void AddTournamen()
    {

    }

    public List<ScoreboardEntry> GenerateSingleRoundRobin(TeamInformation teams)
    {
        List<ScoreboardEntry> matchups = new List<ScoreboardEntry>();

        for (int i = 0; i < teams.name.Count; i++)
        {
            for (int j = i + 1; j < teams.name.Count; j++)
            {
                matchups.Add(new ScoreboardEntry
                {
                    TeamAName = teams.name[i],
                    TeamAColor = teams.color[i],

                    TeamBName = teams.name[j],
                    TeamBColor = teams.color[j],
                });
            }
        }
        currentScoreboardEntryTemp = matchups;
        return matchups;

    }

    public List<ScoreboardEntry> GenerateDoubleRoundRobin(TeamInformation teams)
    {
        List<ScoreboardEntry> matchups = new List<ScoreboardEntry>();

        for (int i = 0; i < teams.name.Count; i++)
        {
            for (int j = i + 1; j < teams.name.Count; j++)
            {
                matchups.Add(new ScoreboardEntry
                {
                    TeamAName = teams.name[i],
                    TeamBName = teams.name[j],

                    TeamAColor = teams.color[i],
                    TeamBColor = teams.color[j],
                });

                matchups.Add(new ScoreboardEntry
                {
                    TeamAName = teams.name[j],
                    TeamBName = teams.name[i],

                    TeamAColor = teams.color[j],
                    TeamBColor = teams.color[i],
                });
            }
        }
        currentScoreboardEntryTemp = matchups;
        return matchups;

    }

    public TournamentEntry GetById(int searchId)
    {
        int index = id.FindIndex(item => item == searchId);
        if (index != -1)
        {
            return new TournamentEntry(
                id[index],
                title[index],
                teams,
                time[index],
                totalMatch[index],
                additionalTime[index],
                mode[index]);
        }
        throw new System.Exception("Tournament with specified ID not found");
    }

    public List<TournamentEntry> GetAll()
    {
        List<TournamentEntry> allEntries = new List<TournamentEntry>();
        for (int i = 0; i < id.Count; i++)
        {
            allEntries.Add(new TournamentEntry(
                id[i],
                title[i],
                teams,
                time[i],
                totalMatch[i],
                additionalTime[i],
                mode[i]));
        }
        return allEntries;
    }
}

[System.Serializable]
public struct TeamInformation
{
    public List<string> name;
    public List<Color> color;
}
[System.Serializable]
public struct TournamentEntry
{
    public int Id;
    public string Title;
    public List<TeamInformation> Teams;
    public float Time;
    public int TotalMatch;
    public float AdditionalTime;
    public TournamentMode Mode;

    public TournamentEntry(int id, string title, List<TeamInformation> teams, float time, int totalMatch, float additionalTime, TournamentMode mode)
    {
        Id = id;
        Title = title;
        Teams = teams;
        Time = time;
        TotalMatch = totalMatch;
        AdditionalTime = additionalTime;
        Mode = mode;
    }
}

public enum TournamentMode { SingleRoundRobin, DoubleRoundRobin }

