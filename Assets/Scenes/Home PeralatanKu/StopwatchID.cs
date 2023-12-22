using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StopwatchID : MonoBehaviour
{

    public int id;
    public string title;
    public int recordNumber;
    public List<int> stopwatchId; 
    public Vector2 rect;

    public DetailedViewed view;
    public StopwatchSave save;
    public StopwatchSO so;

    public TextMeshProUGUI recordTMP;
    public TextMeshProUGUI titleTMP;

    public GameObject recordPrefab;
    public Transform parent;

    private List<GameObject> instantiated = new List<GameObject>();
    private void Awake()
    {
        
        rect = GetComponent<RectTransform>().anchoredPosition;
    }

    

    public void setRecord(int record)
    {
        recordNumber = record;
        recordTMP.text = recordNumber.ToString() + " Records";
    }

    public void Detailed(int sceneIndex)
    {
        
        view.currentViewedStopwatchGroupID = id;
        SceneManager.LoadScene(sceneIndex);
    }


    public void setTitle(string title)
    {
        this.title = title;
        titleTMP.text = title;
        // TMPs
    }

    public void AddRecord(int id)
    {
        recordNumber += 1;
        save.recordNumber[this.id] = recordNumber;
        stopwatchId.Add(id);
        recordTMP.text = recordNumber.ToString() + " Records";
        tanss();
    }

    public void tanss()
    {
        if (instantiated.Count > 0)
        {
            foreach (var item in instantiated)
            {
                DestroyImmediate(item);
            }
        }

        instantiated = new List<GameObject>();
        var ss = Vector2.zero;
        for (int i = 0; i < recordNumber; i++)
        {
            instantiated.Add(Instantiate(recordPrefab, parent, false));
            var a = instantiated[instantiated.Count - 1];

            if (i == 0)
            {
                ss = a.GetComponent<RectTransform>().anchoredPosition;
            }
            else
            {
                a.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, ss.y - 100);

            }

            var texts = a.GetComponentsInChildren<TextMeshProUGUI>();
            Debug.Log(texts.Length);
            texts[0].text = so.stopwatchName[i];
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(so.time[i]);
            texts[1].text = string.Format("{0:D2} : {1:D2} : {2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        }
        Debug.Log("SS");
    }
}
