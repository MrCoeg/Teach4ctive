using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIImageInstantiator : MonoBehaviour
{
    public GameObject imagePrefab;
    public Transform parentTransform; // Assign the parent for instantiated images

    private GameObject currentActiveImage = null;

    public void InstantiateUIImage()
    {
        GameObject imageInstance = Instantiate(imagePrefab, parentTransform);
        EventTrigger trigger = imageInstance.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { ToggleButtons(imageInstance); });
        trigger.triggers.Add(entry);

    }

    private void ToggleButtons(GameObject imageInstance)
    {
        // Find buttons as children and toggle their visibility
        foreach (Transform child in imageInstance.transform)
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }

        // Hide previously active image's buttons
        if (currentActiveImage != null && currentActiveImage != imageInstance)
        {
            foreach (Transform child in currentActiveImage.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        currentActiveImage = imageInstance;
    }
}
