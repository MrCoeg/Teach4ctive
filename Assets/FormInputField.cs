using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FormInputField : MonoBehaviour
{
    public TextMeshProUGUI TMP_text;
    private TouchScreenKeyboard keyboard;
    public event Action OnDataChanged;

    private void Update()
    {
        if (keyboard != null)
        {
            TMP_text.text = keyboard.text;

        }
    }

    public void openAndroidKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open(TMP_text.text, TouchScreenKeyboardType.Default);
        Invoke("hideInputField", 0.1f);
    }
    private void hideInputField()
    {
        TouchScreenKeyboard.hideInput = true;
    }
}
