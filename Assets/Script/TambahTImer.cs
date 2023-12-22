using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TambahTImer : MonoBehaviour
{
    public GameObject timerPrefab;
    public Transform timerParent;
    public float spacing;
    // Start is called before the first frame update
    void Start()
    {
        GetAallTimer();
    }

    public void GetAallTimer()
    {
        var allTimerData = SingletonManager.Instance.timerGroup.GetDataByScoreboardId(-1);
        var instantiated = StaticUIInstantiator.InstantiateUI(allTimerData.Count, timerPrefab, timerParent, spacing);
        var timerInstance = instantiated.Select(script => script.GetComponent<TimerInstance>()).ToList();

        for (int i = 0; i < allTimerData.Count; i++)
        {
            timerInstance[i].Init(allTimerData[i]);
        }
    }

    public void AddTimer()
    {
        StaticSceneChanger.ChangeScene(8);
    }
}
