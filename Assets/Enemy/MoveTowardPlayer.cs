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

        List<Movement> livingPlayers = new List<Movement>();

        for (int i = 0; i < potentialTargets.Length; i++)
        {
            if (potentialTargets[i].GetComponent<Health>().GetCurrentHealth() > 0)
            {
                livingPlayers.Add(potentialTargets[i]);
            }
        }

        if (livingPlayers.Count > 0)
        {
            Transform closestPlayer = livingPlayers[0].transform;
            float distance = Vector3.Distance(transform.position, closestPlayer.position);

            for (int i = 1; i < livingPlayers.Count; i++)
            {
                float nextDistance = Vector3.Distance(transform.position, livingPlayers[i].transform.position);
                if (nextDistance < distance)
                {
                    closestPlayer = livingPlayers[i].transform;
                    distance = nextDistance;
                }
            }

            path.destination = closestPlayer.position;
        }
    }
}
