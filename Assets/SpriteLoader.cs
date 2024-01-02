using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class SpriteLoader : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign a button prefab with an Image component in the inspector
    public GameObject imagePrefab; // UI Image prefab with ImageMover script

    public Transform buttonsParent; // Assign a parent object in the inspector to hold the buttons
    public Transform imageParent; // Parent object for instantiated images



    public string categories;
    public float buttonWidth = 100f; // Default width for buttons
    public float buttonHeight = 100f; // Default height for buttons

    public MainButton mainButton;
    public GameObject toNonActive;
    public void InstantiateButton()
    {
        LoadSpritesFromFolder(categories);
        toNonActive.SetActive(false);
    }

    void LoadSpritesFromFolder(string folderName)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(folderName);
        foreach (Sprite sprite in sprites)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonsParent);
            newButton.GetComponentInChildren<Image>().sprite = sprite;

            // Set the size of the button
            RectTransform rectTransform = newButton.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(buttonWidth, buttonHeight);
            // Set the text of the button to the sprite name

            TextMeshProUGUI textComponent = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = sprite.name;
            }
            newButton.GetComponent<Button>().onClick.AddListener(() => InstantiateImage(sprite));

            mainButton.toDelete.Add(newButton);
        }
    }
    void InstantiateImage(Sprite sprite)
    {
        GameObject newImage = Instantiate(imagePrefab, imageParent);
        newImage.GetComponent<Image>().sprite = sprite;
        // The ImageMover script should already be attached to the imagePrefab
    }
}
