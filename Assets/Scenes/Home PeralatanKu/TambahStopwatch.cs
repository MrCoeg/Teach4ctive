using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class TambahStopwatch : MonoBehaviour
{
    public GameObject stopwatchGroupPrefab;
    public Transform stopwatchGroupParent;
    public float spacing;
    private void Start()
    {
        GetAallStopwatch();
    }

    public void GetAallStopwatch()
    {
        var allStopwatchData = SingletonManager.Instance.stopwatchGroup.GetAllData();
        var instantiated = StaticUIInstantiator.InstantiateUI(allStopwatchData.Count, stopwatchGroupPrefab, stopwatchGroupParent, spacing);
        var stopwatchInstance  = instantiated.Select(script => script.GetComponent<StopwatchGroupInstance>()).ToList();

        for (int i = 0; i < allStopwatchData.Count; i++)
        {
            var details = SingletonManager.Instance.stopwatchGroup.FindDetailsByGroupId(allStopwatchData[i].Item1);
            stopwatchInstance[i].Init(allStopwatchData[i].Item3, details.Count.ToString() + " Records", allStopwatchData[i].Item1);
        }
    }
    public void AddStopwatch()
    {
        StaticSceneChanger.ChangeScene(7);
    }
}
