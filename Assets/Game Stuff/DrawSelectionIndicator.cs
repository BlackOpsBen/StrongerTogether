using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSelectionIndicator : MonoBehaviour
{
    private LineRenderer lr;

    [SerializeField] Vector3[] ringPoints;
    [SerializeField] float ringSize = 1f;

    [SerializeField] Color[] colors;
    [SerializeField] float opacticy = 0.5f;

    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        lr = GetComponent<LineRenderer>();
    }

    private void SetupRingPoints()
    {
        lr.positionCount = ringPoints.Length;
        for (int i = 0; i < ringPoints.Length; i++)
        {
            Vector3 scaledPoints = Vector3.Scale(ringPoints[i], new Vector3(ringSize, ringSize, ringSize));
            Vector3 relative = transform.position + scaledPoints;
            lr.SetPosition(i, relative);
        }
    }

    public void SetColor(int playerIndex)
    {
        Color playerColor = colors[playerIndex];
        playerColor = new Color(playerColor.r, playerColor.g, playerColor.b, opacticy);
        lr.startColor = playerColor;
        lr.endColor = playerColor;
    }

    private void Update()
    {
        SetupRingPoints();
        ShowHide();
    }

    private void ShowHide()
    {
        lr.enabled = movement.GetIsActive();
    }
}
