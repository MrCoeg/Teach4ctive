using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "Pustaka", menuName = "Pustaka/PustakaData")]
public class Pustaka : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<string> title = new List<string>();
    public List<string> modifiedAt = new List<string>(); // This could be a string or DateTime

    public PustakaData FindById(int searchId)
    {
        int index = id.FindIndex(item => item == searchId);
        return index != -1 ? new PustakaData(id[index], title[index], modifiedAt[index]) : default;
    }

    public List<PustakaData> FindAll()
    {
        List<PustakaData> allData = new List<PustakaData>();
        for (int i = 0; i < id.Count; i++)
        {
            allData.Add(new PustakaData(id[i], title[i], modifiedAt[i]));
        }
        return allData;
    }
}

[System.Serializable]
public struct PustakaData
{
    public int Id;
    public string Title;
    public string ModifiedAt;

    public PustakaData(int id, string title, string modifiedAt)
    {
        Id = id;
        Title = title;
        ModifiedAt = modifiedAt;
    }
}
