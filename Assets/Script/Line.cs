using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float smoothness;
    List<Vector2> points;

    public void SetPoints(Vector2 pointsPos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(pointsPos);
            return;
        }

        if (Vector2.Distance(points.Last(), pointsPos) > smoothness)
        {
            SetPoint(pointsPos);
        }
    }

    void SetPoint(Vector2 newPos)
    {
        points.Add(newPos);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, newPos);
    }
}
