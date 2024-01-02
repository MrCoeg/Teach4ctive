using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TambahDesain : MonoBehaviour
{
    public GameObject desainPrefab;
    public Transform desainParent;
    public float spacing;
    // Start is called before the first frame update
    void Start()
    {
        GetAallTimer();
    }

    public void changeScene(int index)
    {
        StaticSceneChanger.ChangeScene(index);
    }

    public void GetAallTimer()
    {
        var allTimerData = SingletonManager.Instance.designKu.GetAll();
        var instantiated = StaticUIInstantiator.InstantiateUI(allTimerData.Count, desainPrefab, desainParent, spacing);
        var timerInstance = instantiated.Select(script => script.GetComponent<DesainInstance>()).ToList();

        for (int i = 0; i < allTimerData.Count; i++)
        {
            timerInstance[i].Init(allTimerData[i]);
        }
    }
}
