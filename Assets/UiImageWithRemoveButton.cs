using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiImageWithRemoveButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject removeButtonPrefab; // Assign the remove button prefab
    private GameObject removeButtonInstance;
    private static GameObject currentActiveRemoveButton; // Static reference to track the current active remove button

    public void OnPointerDown(PointerEventData eventData)
    {
        // Hide the previous active remove button
        if (currentActiveRemoveButton != null)
        {
            currentActiveRemoveButton.SetActive(false);
        }

        // Check if the remove button is already shown for this image
        if (removeButtonInstance == null)
        {
            // Instantiate and position the remove button
            removeButtonInstance = Instantiate(removeButtonPrefab, transform);
            removeButtonInstance.transform.SetAsLastSibling(); // Ensure it's on top
            PositionRemoveButton();

            // Add click listener to the remove button
            removeButtonInstance.GetComponent<Button>().onClick.AddListener(() => Destroy(gameObject));
        }

        // Show the remove button and update the current active button
        removeButtonInstance.SetActive(true);
        currentActiveRemoveButton = removeButtonInstance;
    }

    private void PositionRemoveButton()
    {
        if (removeButtonInstance != null)
        {
            RectTransform rectTransform = removeButtonInstance.GetComponent<RectTransform>();

            // Set the position of the button to the top right of the UI Image
            rectTransform.anchorMin = new Vector2(1, 1);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.pivot = new Vector2(0, 0);
            rectTransform.anchoredPosition = new Vector2(-rectTransform.sizeDelta.x / 2, -rectTransform.sizeDelta.y / 2);
        }
    }
}
