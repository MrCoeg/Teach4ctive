using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollViewController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 panelLocation;
    public RectTransform contentRectTransform;
    public float sensitivity = 0.5f; // Adjust as needed
    public RectTransform scrollViewRectTransform;

    private float contentHeight;
    private float scrollViewHeight;
    void Start()
    {
        contentHeight = contentRectTransform.sizeDelta.y;
        scrollViewHeight = scrollViewRectTransform.rect.height;
        panelLocation = contentRectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.y - data.position.y;
        contentRectTransform.anchoredPosition = panelLocation - new Vector2(0, difference * sensitivity);
    }

    public void OnBeginDrag(PointerEventData data)
    {
        panelLocation = contentRectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData data)
    {
        panelLocation = contentRectTransform.anchoredPosition;
    }
}
