﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringArcChecker : MonoBehaviour
{
    private Weapon weapon;
    private DrawFiringArc drawFiringArc;

    [SerializeField] Transform arcLimit1;
    [SerializeField] Transform arcLimit2;

    public CircleCollider2D circleCollider;

    float arcSizeDegrees;
    float halfArc;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        drawFiringArc = GetComponent<DrawFiringArc>();
        arcSizeDegrees = weapon.GetWeaponTemplate().GetFiringArc();
        halfArc = arcSizeDegrees / 2;
    }

    // Update is called once per frame
    void Update()
    {
        SetArcRotations();

        Vector2 heading = transform.position + transform.right * circleCollider.radius;
        Vector2 arc1Heading = transform.position + arcLimit1.right * circleCollider.radius;
        Vector2 arc2Heading = transform.position + arcLimit2.right * circleCollider.radius;

        if (arcSizeDegrees < 360.0f)
        {
            // Draw heading
            Debug.DrawLine(transform.position, heading, Color.red);

            // Draw arc limits
            Debug.DrawLine(transform.position, arc1Heading, Color.white);
            Debug.DrawLine(transform.position, arc2Heading, Color.yellow);
        }
        Vector3[] rangePoints = new Vector3[2];
        rangePoints[0] = transform.position;
        rangePoints[1] = heading;
        drawFiringArc.SetUpRangeLinePoints(rangePoints);

        Vector3[] arc1Points = new Vector3[2];
        arc1Points[0] = transform.position;
        arc1Points[1] = arc1Heading;
        drawFiringArc.SetUpArc1LinePoints(arc1Points);

        Vector3[] arc2Points = new Vector3[2];
        arc2Points[0] = transform.position;
        arc2Points[1] = arc2Heading;
        drawFiringArc.SetUpArc2LinePoints(arc2Points);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (arcSizeDegrees.Equals(360.0f))
        {
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
        }
    }

    private void SetArcRotations()
    {
        Vector3 eulerRotation1 = transform.rotation.eulerAngles;
        Vector3 eulerRotation2 = transform.rotation.eulerAngles;
        eulerRotation1 = new Vector3(eulerRotation1.x, eulerRotation1.y, eulerRotation1.z + halfArc);
        eulerRotation2 = new Vector3(eulerRotation2.x, eulerRotation2.y, eulerRotation2.z - halfArc);
        arcLimit1.rotation = Quaternion.Euler(eulerRotation1);
        arcLimit2.rotation = Quaternion.Euler(eulerRotation2);
    }

    public bool CheckIsInArc(Transform target)
    {
        Vector2 a = target.position - transform.position;
        Vector2 b = transform.right;

        float angle = Vector2.Angle(a, b);

        if (angle > halfArc)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
