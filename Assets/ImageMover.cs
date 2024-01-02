using UnityEngine;
using UnityEngine.EventSystems;

public class ImageMover : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    // For scaling
    private float initialDistance;
    private Vector3 initialScale;

    private bool isText;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        if (GetComponent<textInputHandler>() != null)
        {
            isText = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Reset scale parameters when drag starts
        if (Input.touchCount >= 2)
        {
            initialDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            initialScale = rectTransform.localScale;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isText)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        }

        // Handle scaling
        if (Input.touchCount >= 2)
        {
            Vector2 touch0, touch1;
            touch0 = Input.GetTouch(0).position;
            touch1 = Input.GetTouch(1).position;

            float currentDistance = Vector2.Distance(touch0, touch1);
            if (Mathf.Approximately(initialDistance, 0))
            {
                return; // Avoid division by zero
            }

            float scaleFactor = currentDistance / initialDistance;
            rectTransform.localScale = initialScale * scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Additional code if needed when drag ends
    }
}
