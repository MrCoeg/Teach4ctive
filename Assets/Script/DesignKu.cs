using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "DesignKu", menuName = "ScriptableObject/DesignKu")]
public class DesignKu : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<int> userId = new List<int>();
    public List<string> title = new List<string>();
    public List<string> modifiedAt = new List<string>();
    public List<int> uiId = new List<int>();

    public DesignKuEntry GetById(int designId)
    {
        int index = id.IndexOf(designId);
        if (index != -1)
        {
            return new DesignKuEntry
            {
                Id = id[index],
                UserId = userId[index],
                Title = title[index],
                ModifiedAt = modifiedAt[index],
                UiId = uiId[index],
            };
        }
        throw new System.Exception("DesignKu with specified ID not found");
    }

    public List<DesignKuEntry> GetAll()
    {
        List<DesignKuEntry> allEntries = new List<DesignKuEntry>();
        for (int i = 0; i < id.Count; i++)
        {
            allEntries.Add(new DesignKuEntry
            {
                Id = id[i],
                UserId = userId[i],
                Title = title[i],
                ModifiedAt = modifiedAt[i],
                UiId = uiId[i],
            });
        }
        return allEntries;
    }

    public void UpdateById(int designId, DesignKuEntry updatedEntry)
    {
        int index = id.IndexOf(designId);
        if (index != -1)
        {
            userId[index] = updatedEntry.UserId;
            title[index] = updatedEntry.Title;
            modifiedAt[index] = updatedEntry.ModifiedAt;
            uiId[index] = updatedEntry.UiId;
        }
        else
        {
            throw new System.Exception("DesignKu with specified ID not found for update");
        }
    }
}



public struct DesignKuEntry
{
    public int Id;
    public int UserId;
    public string Title;
    public string ModifiedAt;
    public int UiId;
}
