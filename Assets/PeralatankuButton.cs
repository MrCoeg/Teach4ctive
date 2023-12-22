using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeralatankuButton : MonoBehaviour
{

    public void Stopwatch()
    {
        StaticSceneChanger.ChangeScene(2);

    }

    public void Timer()
    {
        StaticSceneChanger.ChangeScene(4);
    }

    public void BaganPertandingan()
    {
        StaticSceneChanger.ChangeScene(5);
    }

    public void Turnamen()
    {
        StaticSceneChanger.ChangeScene(6);

    }
}
