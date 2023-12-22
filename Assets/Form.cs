using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Form : MonoBehaviour
{
    public List<FormInputField> formInputFields = new List<FormInputField>();
    public Button button;
    public GameObject prefab;
    public Transform parent;
    private void Awake()
    {
        button.onClick.AddListener(OnSubmit);
    }

    public void OnSubmit()
    {
        List<string> stringList = formInputFields.Select(script => script.TMP_text.text).ToList();

        var isSuccess = SingletonManager.Instance.credentials.CheckCredentials(stringList[0], stringList[1]);


        if (isSuccess)
        {
            StaticSceneChanger.ChangeScene(2);
        }
        else
        {
            Notification.Alert("NotWow", prefab, parent);

        }
    }

}
