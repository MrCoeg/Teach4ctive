using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TexttTEst : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string inputtext;
    public Rect rect;
    private void Awake()
    {
       
        var size = text.GetPreferredValues(text.text);
        var rects = text.rectTransform;
        rects.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        rects.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
    }
    private void Update()
    {



    }
}
