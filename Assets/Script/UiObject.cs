using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "UIObject", menuName = "Design/UIObject")]
public class UiObject : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<int> designKuId = new List<int>();
    public List<bool> isIcon = new List<bool>();
    public List<bool> isText = new List<bool>();
    public List<Vector2> anchoredPosition = new List<Vector2>();
    public List<string> text = new List<string>(); // Empty if icon
    public List<string> iconName = new List<string>(); // Name if it is an icon
    public List<Color> textColor = new List<Color>(); // White if icon
    public List<int> textSize = new List<int>();
    public List<Vector2> iconSize = new List<Vector2>();


    public List<UIObjectData> GetByDesignKuId(int designKuId)
    {
        List<UIObjectData> matchingObjects = new List<UIObjectData>();

        for (int i = 0; i < this.designKuId.Count; i++)
        {
            if (this.designKuId[i] == designKuId)
            {
                matchingObjects.Add(new UIObjectData
                {
                    id = this.id[i],
                    designKuId = this.designKuId[i],
                    isIcon = this.isIcon[i],
                    isText = this.isText[i],
                    anchoredPosition = this.anchoredPosition[i],
                    text = this.text[i],
                    iconName = this.iconName[i],
                    textColor = this.textColor[i],
                    textSize = this.textSize[i],
                    iconSize = this.iconSize[i]
                });
            }
        }

        return matchingObjects;
    }

    public void AddUI(UIObjectData data)
    {
        id.Add(data.id);
        designKuId.Add(data.designKuId);
        isIcon.Add(data.isIcon);
        isText.Add(data.isText);
        anchoredPosition.Add(data.anchoredPosition);
        text.Add(data.text);
        iconName.Add(data.iconName);
        textColor.Add(data.textColor);
        textSize.Add(data.textSize);
        iconSize.Add(data.iconSize);
    }
}

[System.Serializable]
public struct UIObjectData
{
    public int id;
    public int designKuId;
    public bool isIcon;
    public bool isText;
    public Vector2 anchoredPosition;
    public string text;
    public string iconName;
    public Color textColor;
    public int textSize;
    public Vector2 iconSize;

    // Method to create a default UIObjectData
    public static UIObjectData CreateUI()
    {
        return new UIObjectData
        {
            // Set default values
            id = 0,
            designKuId = 0,
            isIcon = false,
            isText = false,
            anchoredPosition = Vector2.zero,
            text = "",
            iconName = "",
            textColor = Color.white,
            textSize = 12,
            iconSize = new Vector2(100, 100)
        };
    }
}
