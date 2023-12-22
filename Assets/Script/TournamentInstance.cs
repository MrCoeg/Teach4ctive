using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TournamentInstance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpPro1;
    [SerializeField] public Button button;
    [SerializeField] private int id;



    // Initialization method
    public void Init(TournamentEntry entry)
    {

        if (id >= 0)
        {
            SingletonManager.Instance.currentTurnamenGroupId = entry.Id;

            button.onClick.AddListener(() => {
                SingletonManager.Instance.currentStopwatchGroupId = this.id;
                var scr = GameObject.Find("ReferenceTambahPertandingan").GetComponent<TambahScoreboard>();
                scr.Refresh(entry.Id);
            });
        }

        if (tmpPro1 != null)
            tmpPro1.text = entry.Title;
    }
}
