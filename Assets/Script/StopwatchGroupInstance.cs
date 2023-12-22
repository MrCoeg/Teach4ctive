using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StopwatchGroupInstance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpPro1;
    [SerializeField] private TextMeshProUGUI tmpPro2;
    [SerializeField] public Button button;
    [SerializeField] private int id;



    // Initialization method
    public void Init(string textForTMPPro1, string textForTMPPro2, int id)
    {

        if (id >= 0)
        {
            this.id = id;

            button.onClick.AddListener(() => {
                SingletonManager.Instance.currentStopwatchGroupId = this.id;
                StaticSceneChanger.ChangeScene(3);
            });
        }

        if (tmpPro1 != null)
            tmpPro1.text = textForTMPPro1;

        if (tmpPro2 != null)
            tmpPro2.text = textForTMPPro2;
    }
}
