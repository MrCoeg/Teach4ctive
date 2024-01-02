using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAsset : MonoBehaviour
{
    public GameObject spritePrefab; // Assign this in the inspector
    public Sprite spriteToInstantiate; // Assign the specific sprite for this button in the inspector


    public void OnButtonClick()
    {
        GameObject newObject = Instantiate(spritePrefab, Vector3.zero, Quaternion.identity);

    }
}
