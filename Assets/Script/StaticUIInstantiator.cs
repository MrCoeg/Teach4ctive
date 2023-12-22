using UnityEngine;
using System.Collections.Generic;

public static class StaticUIInstantiator
{
    public static List<GameObject> InstantiateUI(int count, GameObject prefab, Transform parent, float space)
    {
        List<GameObject> instantiatedObjects = new List<GameObject>();
        float currentYPosition = 0f;

        for (int i = 0; i < count; i++)
        {
            GameObject instance = Object.Instantiate(prefab, parent);
            RectTransform rectTransform = instance.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, currentYPosition);
                currentYPosition -= space; // Move down for the next element
            }

            instantiatedObjects.Add(instance);
        }

        return instantiatedObjects;
    }

    public static List<GameObject> InstantiateUIWithButton(int count, GameObject prefab, GameObject button,Transform parent, float space)
    {
        List<GameObject> instantiatedObjects = new List<GameObject>();
        float currentYPosition = 0f;

        for (int i = 0; i < count; i++)
        {
            GameObject instance = Object.Instantiate(prefab, parent);
            RectTransform rectTransform = instance.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, currentYPosition);
                currentYPosition -= space; // Move down for the next element
            }

            instantiatedObjects.Add(instance);
        }

        GameObject a = Object.Instantiate(button, parent);
        RectTransform b = a.GetComponent<RectTransform>();

        if (b != null)
        {
            b.anchoredPosition = new Vector2(b.anchoredPosition.x, currentYPosition);
        }

        return instantiatedObjects;
    }

    public static List<GameObject> InstantiateUIAtFirstChild(int count, GameObject prefab, Transform parent, float space)
    {
        List<GameObject> instantiatedObjects = new List<GameObject>();
        float currentYPosition = 0f;

        for (int i = 0; i < count; i++)
        {
            GameObject instance = Object.Instantiate(prefab, parent);
            RectTransform rectTransform = instance.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, currentYPosition);
                currentYPosition -= space; // Move down for the next element
            }

            // Set the instantiated object as the first child of the parent
            instance.transform.SetSiblingIndex(0);

            instantiatedObjects.Add(instance);
        }

        return instantiatedObjects;
    }

}
