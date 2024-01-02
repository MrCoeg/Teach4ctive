using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; // Namespace for Text Mesh Pro

public class textInputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private TMP_InputField inputField;

    private bool isDragging = false;
    private float tapTimeThreshold = 0.2f; // Time threshold to distinguish between tap and drag
    private float tapTime = 0f;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        inputField = GetComponent<TMP_InputField>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        tapTime = Time.time;
        isDragging = false; // Initially assume it's not a drag
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Time.time - tapTime <= tapTimeThreshold && !isDragging)
        {
            // It's a tap, not a drag
            if (inputField != null)
            {
                inputField.ActivateInputField(); // Activate the input field only if it's a tap
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging && Time.time - tapTime > tapTimeThreshold)
        {
            isDragging = true; // It's a drag if it lasts longer than the threshold
        }

        if (isDragging)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}
