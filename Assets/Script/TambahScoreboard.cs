using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TambahScoreboard : MonoBehaviour
{
    public GameObject scoreboardPrefab;
    public Transform scoreboardParent;
    public float spacing;
    // Start is called before the first frame update

    List<GameObject> instantiated;
    void Start()
    {
        GetAallTimer();
    }

    public void GetAallTimer()
    {
        var allTimerData = SingletonManager.Instance.scoreboard.GetDataByTournamentId(-1);
        instantiated = StaticUIInstantiator.InstantiateUI(allTimerData.Count, scoreboardPrefab, scoreboardParent, spacing);
        var timerInstance = instantiated.Select(script => script.GetComponent<ScoreboardInstance>()).ToList();

        for (int i = 0; i < allTimerData.Count; i++)
        {
            timerInstance[i].Init(allTimerData[i]);
        }
    }

    public void Refresh(int id)
    {

        foreach (var item in instantiated)
        {
            DestroyImmediate(item);
        }
        
        var allTimerData = SingletonManager.Instance.scoreboard.GetDataByTournamentId(id);
        instantiated = StaticUIInstantiator.InstantiateUI(allTimerData.Count, scoreboardPrefab, scoreboardParent, spacing);
        var timerInstance = instantiated.Select(script => script.GetComponent<ScoreboardInstance>()).ToList();

        for (int i = 0; i < allTimerData.Count; i++)
        {
            timerInstance[i].Init(allTimerData[i]);
        }
    }
}
