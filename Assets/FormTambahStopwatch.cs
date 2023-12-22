using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FormTambahStopwatch : MonoBehaviour
{
    public List<FormInputField> formInputFields = new List<FormInputField>();
    public Button button;
    public Button buttonBack;

    public GameObject prefab;
    public Transform parent;
    public int sceneindex;

    private void Awake()
    {
        button.onClick.AddListener(OnSubmit);
        buttonBack.onClick.AddListener(() =>
        {
            StaticSceneChanger.ChangeScene(sceneindex);
        });
    }
    public void OnSubmit()
    {
        List<string> stringList = formInputFields.Select(script => script.TMP_text.text).ToList();

        var error = SingletonManager.Instance.stopwatchGroup.AddStopwatchGroup(new StopwatchGroupDetail { 
            Id = SingletonManager.Instance.stopwatchGroup.id.Count,
            Title = stringList[0]
        });


        if (error.Item1)
        {
            StaticSceneChanger.ChangeScene(sceneindex);
        }
        else
        {
            Notification.Alert(error.Item2, prefab, parent);

        }
    }
}
