using UnityEngine;
using TMPro;

public static class Notification
{
    private static GameObject notificationPrefab;

    public static void Alert(string message, GameObject prefab, Transform parent)
    {
        notificationPrefab = prefab;

        GameObject notificationInstance = Object.Instantiate(notificationPrefab, parent, false);
        TMP_Text messageText = notificationInstance.GetComponentInChildren<TMP_Text>();
        if (messageText != null)
        {
            messageText.text = message;
        }

        // Optional: Add logic to automatically destroy the notification after a few seconds
        Object.Destroy(notificationInstance, 5f); // Destroy after 5 seconds
    }
}
