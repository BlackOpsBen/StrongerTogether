using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFiringArc : MonoBehaviour
{
    [SerializeField] LineRenderer rangeLine;
    [SerializeField] LineRenderer arc1Line;
    [SerializeField] LineRenderer arc2Line;
    private Vector3[] rangePoints;
    private Vector3[] arc1Points;
    private Vector3[] arc2Points;

    public void SetUpRangeLinePoints(Vector3[] points)
    {
        rangeLine.positionCount = points.Length;
        this.rangePoints = points;
    }

    public void SetUpArc1LinePoints(Vector3[] points)
    {
        arc1Line.positionCount = points.Length;
        this.arc1Points = points;
    }

    public void SetUpArc2LinePoints(Vector3[] points)
    {
        arc2Line.positionCount = points.Length;
        this.arc2Points = points;
    }

    private void Update()
    {
        if (rangePoints != null)
        {
            for (int i = 0; i < rangePoints.Length; i++)
            {
                rangeLine.SetPosition(i, rangePoints[i]);
            }
        }

        if (arc1Points != null)
        {
            for (int i = 0; i < arc1Points.Length; i++)
            {
                arc1Line.SetPosition(i, arc1Points[i]);
            }
        }

        if (arc2Points != null)
        {
            for (int i = 0; i < arc2Points.Length; i++)
            {
                arc2Line.SetPosition(i, arc2Points[i]);
            }
        }
    }
}
