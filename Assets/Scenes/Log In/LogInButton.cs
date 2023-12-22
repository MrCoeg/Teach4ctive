using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogInButton : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    private TouchScreenKeyboard keyboard;
    private int currentId;

    private void Update()
    {

        text[currentId].text = keyboard.text;
    }

    public void openAndroidKeyboard(int formId)
    {
        currentId = formId;
        keyboard = TouchScreenKeyboard.Open(text[currentId].text, TouchScreenKeyboardType.Default);
        Invoke("hideInputField", 0.1f);
    }
    private void hideInputField()
    {
        TouchScreenKeyboard.hideInput = true;
    }
}
