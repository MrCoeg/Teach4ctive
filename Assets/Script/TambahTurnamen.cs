using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class TambahTurnamen : MonoBehaviour
{
    public GameObject turnamenPrefab;
    public Transform turnamenParent;
    public float spacing;

    public float contentSize;
    public float contentpadding;
    public float contentspacing;




    void Start()
    {
        GetAallTimer();
    }

    public void Tambah(int scene)
    {
        StaticSceneChanger.ChangeScene(scene);
    }

    public void GetAallTimer()
    {
        var allTimerData = SingletonManager.Instance.tournament.GetAll();
        var instantiated = StaticUIInstantiator.InstantiateUI(allTimerData.Count, turnamenPrefab, turnamenParent, spacing);
        var timerInstance = instantiated.Select(script => script.GetComponent<TournamentInstance>()).ToList();

        var parentRect = turnamenParent.GetComponent<RectTransform>();
        var anchor = new Vector2((contentpadding + (contentSize * allTimerData.Count) + (contentpadding * allTimerData.Count-1))/2, parentRect.anchoredPosition.y);
        parentRect.anchoredPosition = anchor;


        for (int i = 0; i < allTimerData.Count; i++)
        {
            timerInstance[i].Init(allTimerData[i]);
        }
    }
}
