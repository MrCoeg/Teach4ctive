using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DesainInstance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpPro1;
    [SerializeField] private TextMeshProUGUI tmpPro2;
    [SerializeField] public Button button;

    public DesignKuEntry entry;
    public void Init(DesignKuEntry entry)
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

        if (tmpPro2 != null)
            tmpPro2.text = entry.ModifiedAt;
    }
}
