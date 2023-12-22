using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Morph : MonoBehaviour
{
    public RectTransform targetPosition;
    public float morphTime = 1.0f;
    public Vector3 targetScale = new Vector3(1, 1, 1); // Set your target scale here
    public Vector3 targetRotation = new Vector3(0, 0, 0); // Set your target rotation here (in degrees)
    public Color targetColor = Color.white; // Set your target color here
    private RectTransform rectTransform;
    private Image image;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("ImageMorphToPosition script requires an Image component on the same GameObject.");
        }
    }

    public void StartMorph()
    {
        StartCoroutine(MorphToPosition());
    }

    private IEnumerator MorphToPosition()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = targetPosition.anchoredPosition;
        Vector3 startScale = rectTransform.localScale;
        Quaternion startRotation = rectTransform.rotation;
        Quaternion endRotation = Quaternion.Euler(targetRotation);
        Color startColor = image.color;
        float elapsedTime = 0;

        while (elapsedTime < morphTime)
        {
            float progress = elapsedTime / morphTime;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, progress);
            rectTransform.localScale = Vector3.Lerp(startScale, targetScale, progress);
            rectTransform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
            image.color = Color.Lerp(startColor, targetColor, progress);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition;
        rectTransform.localScale = targetScale;
        rectTransform.rotation = endRotation;
        image.color = targetColor;
    }
}