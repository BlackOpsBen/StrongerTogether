using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveTowardPlayer : MonoBehaviour
{
    [SerializeField] AIPath path;

    private void Update()
    {
        Movement[] potentialTargets = FindObjectsOfType<Movement>();

        Transform closestPlayer = potentialTargets[0].transform;
        float distance = Vector3.Distance(transform.position, closestPlayer.position);

        for (int i = 1; i < potentialTargets.Length; i++)
        {
            float nextDistance = Vector3.Distance(transform.position, potentialTargets[i].transform.position);
            if (nextDistance < distance)
            {
                closestPlayer = potentialTargets[i].transform;
                distance = nextDistance;
            }
        }

        path.destination = closestPlayer.position;
    }
}
