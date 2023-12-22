using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public GameObject recordPrefab;
    public Transform parent;

    public GameObject groupPrefab;

    public float groupSpace;
    public float space;
    private void Awake()
    {
        var groupId = SingletonManager.Instance.currentStopwatchGroupId;
        var group = SingletonManager.Instance.stopwatchGroup.GetItemById(groupId);
        var details = SingletonManager.Instance.stopwatchGroup.FindDetailsByGroupId(groupId);

        var instantiated = StaticUIInstantiator.InstantiateUI(1, groupPrefab, parent, groupSpace);
        var stopwatchInstance = instantiated.Select(script => script.GetComponent<StopwatchGroupInstance>()).ToList();
        stopwatchInstance[0].Init(group.Item3, details.Count.ToString() + " Records", -1);


        instantiated =  StaticUIInstantiator.InstantiateUI(details.Count, recordPrefab, instantiated[0].transform, space);
        var detailInstance = instantiated.Select(script => script.GetComponent<StopwatchDetailInstance>()).ToList();
        for (int i = 0; i < detailInstance.Count; i++)
        {
            detailInstance[i].Init(details[i].Title, details[i].MaxTime);
        }
    }
}
