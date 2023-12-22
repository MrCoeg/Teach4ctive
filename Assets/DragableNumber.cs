using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


using TMPro;

public class DragableNumber : MonoBehaviour, IPointerUpHandler, IDragHandler
{
    public float value;
    public float smoothness;

    private Vector2 originalPosition;
    private Vector2 temp;

    private RectTransform rectTransform;

    public float limit;
    public TextMeshProUGUI text;

    private float fDistance = 0;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        temp = eventData.delta;
        var distance = Vector2.Distance(originalPosition, temp);

        if (originalPosition.y > temp.y)
        {
            if (fDistance == 0)
            {
                value += distance / smoothness;
                fDistance = distance;
            }
            else
            {

                value += (distance % fDistance) / smoothness;
                fDistance = distance;
            }
        }
        else if (originalPosition.y < temp.y)
        {
            if (fDistance == 0)
            {
                value -= distance / smoothness;
                fDistance = distance;
            }
            else
            {

                value -= (distance % fDistance) / smoothness;
                fDistance = distance;
            }
        }

        if (value > limit)
        {
            value = 0;
        }
        else if(value < 0)
        {
            value = limit;
        }

        text.text = ((int)value).ToString();



        Debug.Log(value);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Return the image to its original position
        rectTransform.anchoredPosition = originalPosition;
    }
}
