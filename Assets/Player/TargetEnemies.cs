using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemies : MonoBehaviour
{
    public WeaponTemplate weapon;

    public List<Transform> rangedTargets = new List<Transform>();

    public List<Transform> arcTargets = new List<Transform>();

    public Transform actualTarget;

    private FiringArcChecker firingArcChecker;

    private void Start()
    {
        firingArcChecker = GetComponent<FiringArcChecker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Target"))
        {
            rangedTargets.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (rangedTargets.Contains(collision.transform))
        {
            rangedTargets.Remove(collision.transform);
        }
    }

    private void Update()
    {
        RemoveDeadTargets();
        FindTargetsInArc();
        if (arcTargets.Count > 0)
        {
            actualTarget = FindClosestTarget();
            weapon.Shoot(actualTarget);
        }
        else
        {
            actualTarget = null;
        }
    }

    private void RemoveDeadTargets()
    {
        for (int i = 0; i < rangedTargets.Count; i++)
        {
            if (rangedTargets[i] == null)
            {
                rangedTargets.RemoveAt(i);
            }
        }
    }

    private void FindTargetsInArc()
    {
        arcTargets = new List<Transform>();
        for (int i = 0; i < rangedTargets.Count; i++)
        {
            if (CheckIsInFiringArc(rangedTargets[i]))
            {
                arcTargets.Add(rangedTargets[i]);
            }
        }
    }

    private Transform FindClosestTarget()
    {
        Transform closestTarget = arcTargets[0];
        float closestTargetDist = Vector2.Distance(transform.position, closestTarget.position);

        for (int i = 1; i < arcTargets.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, arcTargets[i].position);
            if (distance < closestTargetDist)
            {
                closestTarget = arcTargets[i];
                closestTargetDist = distance;
            }
        }
        return closestTarget;
    }

    private bool CheckIsInFiringArc(Transform target)
    {
        return firingArcChecker.CheckIsInArc(target);
    }
}
