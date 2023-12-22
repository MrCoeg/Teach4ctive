using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/stopwatchSO", fileName = "stopwatchSO")]
public class StopwatchSO : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<string> stopwatchName = new List<string>(); 
    public List<float> time = new List<float>();


}
