using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
public class AlatButton : MonoBehaviour
{
    public GameObject drawTools;
    public RectTransform uiElement; // Assign the UI element to capture
    public void Draw()
    {
         drawTools.SetActive(!drawTools.activeSelf);
    }

    public void Export()
    {
        StartCoroutine(save());
    }

    IEnumerator save()
    {
        yield return new WaitForEndOfFrame();
        // Take a full screenshot
        Texture2D fullScreenShot = ScreenCapture.CaptureScreenshotAsTexture();

        // Calculate the coordinates and size of the UI element
        Vector2 size = Vector2.Scale(uiElement.rect.size, uiElement.lossyScale);
        Rect rect = new Rect(uiElement.position.x, uiElement.position.y, size.x, size.y);
        rect.x -= (uiElement.pivot.x * size.x);
        rect.y -= ((1.0f - uiElement.pivot.y) * size.y);

        // Crop the screenshot
        Texture2D croppedTexture = new Texture2D((int)rect.width, (int)rect.height);
        Color[] pixels = fullScreenShot.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        // Save or use the cropped texture
        // For example, save it as a PNG file
        byte[] bytes = croppedTexture.EncodeToPNG();

        string name = string.Format("{0}_Capture{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(bytes, Application.productName + " Captures", name));

        // Clean up
        Destroy(fullScreenShot);
        Destroy(croppedTexture);
    }
}
