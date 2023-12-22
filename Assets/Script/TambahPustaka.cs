using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TambahPustaka : MonoBehaviour
{
    public GameObject pustakaPrefab;
    public Transform pustakaParent;
    public float spacing;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        GetAallTimer();
    }

    public void GetAallTimer()
    {
        var allTimerData = SingletonManager.Instance.pustaka.FindAll();
        var instantiated = StaticUIInstantiator.InstantiateUI(allTimerData.Count, pustakaPrefab, pustakaParent, spacing);
        var timerInstance = instantiated.Select(script => script.GetComponent<PustakaInstance>()).ToList();

        for (int i = 0; i < allTimerData.Count; i++)
        {
            timerInstance[i].Init(allTimerData[i]);
        }
    }
}
