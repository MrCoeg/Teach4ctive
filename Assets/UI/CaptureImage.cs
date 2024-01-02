using UnityEngine;
using System.Collections;
using System.IO;

public class CaptureImage : MonoBehaviour
{
    public RenderTexture renderTexture;

    void Start()
    {
        // Call this function to capture and save the image
        StartCoroutine( CaptureAndSave());
    }

    IEnumerator CaptureAndSave()
    {
        yield return new WaitForEndOfFrame();
        RenderTexture.active = renderTexture;
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        byte[] imageBytes = texture2D.EncodeToPNG();
        Debug.Log(Application.dataPath + "/CapturedImage.png");
        File.WriteAllBytes(Application.dataPath + "/CapturedImage.png", imageBytes);

        Destroy(texture2D);
        yield return null;
    }
}
