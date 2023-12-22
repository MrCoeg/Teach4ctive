using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StopwatcSave", menuName = "Stopwatch/StopwatchSave")]
public class StopwatchSave : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<string> title= new List<string>();
    public List<int> recordNumber = new List<int>();
    public List<Vector2> rect = new List<Vector2>();

    public void Save(StopwatchID id)
    {
        this.id.Add(id.id);
        title.Add(id.title);
        recordNumber.Add(id.recordNumber);
        rect.Add(id.rect);
    }
}
