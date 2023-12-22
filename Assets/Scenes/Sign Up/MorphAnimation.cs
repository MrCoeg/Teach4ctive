using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MorphAnimation : MonoBehaviour
{
    public RectTransform buttonTransform;
    public float animationTime = 0.5f;
    private bool isRectangular = false;
    private Vector2 originalSize;
    private Vector2 targetSize = new Vector2(150, 50); // Target size for rectangular shape

    void Start()
    {
        if (buttonTransform == null)
        {
            buttonTransform = GetComponent<RectTransform>();
        }
        originalSize = buttonTransform.sizeDelta;
    }

    public void ToggleMorph()
    {
        StopAllCoroutines();
        StartCoroutine(Morph());
    }

    private IEnumerator Morph()
    {
        float elapsedTime = 0;
        Vector2 startingSize = buttonTransform.sizeDelta;
        Vector2 endSize = isRectangular ? originalSize : targetSize;

        while (elapsedTime < animationTime)
        {
            buttonTransform.sizeDelta = Vector2.Lerp(startingSize, endSize, (elapsedTime / animationTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        buttonTransform.sizeDelta = endSize;
        isRectangular = !isRectangular;
    }
}
