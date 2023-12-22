using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PustakaInstance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpPro1;
    [SerializeField] public Button button;

    public PustakaData entry;
    public void Init(PustakaData entry)
    {
        this.entry = entry;
        if (entry.Id >= 0)
        {

            button.onClick.AddListener(() =>
            {
                SingletonManager.Instance.currentDesignGroupId = entry.Id;
                StaticSceneChanger.ChangeScene(3);
            });
        }

        if (tmpPro1 != null)
            tmpPro1.text = entry.Title;
    }
}


