using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchButton : MonoBehaviour
{
    public GameObject stopwatchPrefab;
    public Transform parent;
    public float space;
    public List<StopwatchID> stopwatchs = new List<StopwatchID>();
    public StopwatchSave save;

    public DetailedViewed view;
    public GameObject dialog;

    private void Awake()
    {
        for (int i = 0; i < save.title.Count; i++)
        
        {
            var instantiated = Instantiate(stopwatchPrefab, parent, false);

            var recttrans = instantiated.GetComponent<RectTransform>();
            if (stopwatchs.Count == 0)
            {
                recttrans.anchoredPosition = new Vector2(0, 178 + space);

            }
            else
            {
                recttrans.anchoredPosition = new Vector2(0, stopwatchs[stopwatchs.Count - 1].rect.y + space);

            }
            stopwatchs.Add(instantiated.GetComponent<StopwatchID>());
            var stId = stopwatchs[stopwatchs.Count - 1];
            stId.id = stopwatchs.Count - 1;
            stId.view = view;
            stId.save = save;
            stId.rect = recttrans.anchoredPosition;
            stId.setRecord(save.recordNumber[i]);
            stId.setTitle(save.title[i]);
        }
    }

    public void OpenDialog()
    {
        dialog.SetActive(true);
    }

    public void AddStopwatchGroup(string title)
    {
        var instantiated = Instantiate(stopwatchPrefab, parent, false);
        
        var recttrans = instantiated.GetComponent<RectTransform>();
        if (stopwatchs.Count == 0)
        {
            recttrans.anchoredPosition = new Vector2(0, 178 + space);
            
        }
        else
        {
            recttrans.anchoredPosition = new Vector2(0, stopwatchs[stopwatchs.Count - 1].rect.y + space);

        }
        stopwatchs.Add(instantiated.GetComponent<StopwatchID>());
       
        var stId = stopwatchs[stopwatchs.Count - 1];
        stId.id = stopwatchs.Count - 1;
        stId.rect = recttrans.anchoredPosition;
        stId.setRecord(0);
        stId.setTitle(title);
        stId.view = view;
        stId.save = save;
        save.Save(stId);

    }
}
