using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GameObject newLine = Instantiate(linePrefab);
                activeLine = newLine.GetComponent<Line>();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                activeLine = null;
            }

            if (activeLine != null)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                activeLine.SetPoints(touchPos);
            }
        }
    }
}
