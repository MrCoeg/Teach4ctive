using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneTo(int index)
    {
        StaticSceneChanger.ChangeScene(index);
    }
}
