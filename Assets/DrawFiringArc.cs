using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFiringArc : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3[] points;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetUpLinePoints(Vector3[] points)
    {
        lineRenderer.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        if (points != null)
        {
            for (int i = 0; i < points.Length; i++)
            {
                lineRenderer.SetPosition(i, points[i]);
            }
        }
    }
}
