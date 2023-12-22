using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LiveDrawInstancer : MonoBehaviour
{
    int drawId;
    public GameObject iconPrefab;
    public GameObject textPrefab;

    public Transform parentTransform;

    private void Awake()
    {
        drawId = SingletonManager.Instance.currentDesignGroupId;
        LoadDraw();
    }

    public void LoadDraw()
    {
        var uiElements = SingletonManager.Instance.uiObject.GetByDesignKuId(drawId);

        foreach (var element in uiElements)
        {
            if (element.isIcon)
            {
                GameObject iconInstance = Instantiate(iconPrefab, parentTransform);
                iconInstance.GetComponent<RectTransform>().anchoredPosition = element.anchoredPosition;
                Image iconImage = iconInstance.GetComponent<Image>();
                iconImage.sprite = Resources.Load<Sprite>("Icons/" + element.iconName);
                iconImage.color = element.textColor; // Assuming the icon uses the textColor field for its color
                iconImage.rectTransform.sizeDelta = element.iconSize;
            }
            else if (element.isText)
            {
                GameObject textInstance = Instantiate(textPrefab, parentTransform);
                textInstance.GetComponent<RectTransform>().anchoredPosition = element.anchoredPosition;
                TextMeshProUGUI textComponent = textInstance.GetComponent<TextMeshProUGUI>(); // Use Text if not using TextMeshPro
                textComponent.text = element.text;
                textComponent.fontSize = element.textSize;
                textComponent.color = element.textColor;
            }
        }
    }


}
