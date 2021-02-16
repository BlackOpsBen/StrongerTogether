using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowPlayer : MonoBehaviour
{
    public List<Transform> targets;

    public float trackSpeed = 5f;

    public float minZoom = 10f;

    public float maxZoom = 3f;

    private Camera cam;

    Bounds bounds;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].GetComponent<Health>().GetCurrentHealth() < 1)
            {
                targets.RemoveAt(i);
            }
        }
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        bounds = GetBounds();

        Move();
        Zoom();
        
    }

    private Bounds GetBounds()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds;
    }

    private void Move()
    {
        Vector3 centerPoint = bounds.center;

        Vector3 newPosition = new Vector3(centerPoint.x, centerPoint.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * trackSpeed);
    }

    private void Zoom()
    {
        float largestSide = Mathf.Max(bounds.size.x, bounds.size.y);
        float newZoom = Mathf.Lerp(maxZoom, minZoom, largestSide / 15f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime * trackSpeed);
    }
}
