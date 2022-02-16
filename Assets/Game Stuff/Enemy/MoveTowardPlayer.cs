using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveTowardPlayer : MonoBehaviour
{
    [SerializeField] AIPath path;
    [SerializeField] float chaseDistance = 20f;

    //private GameObject[] waypoints;
    //private bool headedToWaypoint = false;
    //private Transform targetWaypoint;
    //[SerializeField] float waypointArrivalDist = 2f;

    private void Start()
    {
        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        //HeadToRandomWaypoint();
        HeadToNearbySpot();
    }

    private void Update()
    {
        Movement[] potentialPlayerTargets = FindObjectsOfType<Movement>();

        List<Movement> validPlayerTargets = new List<Movement>();

        for (int i = 0; i < potentialPlayerTargets.Length; i++)
        {
            bool isWithinChaseDist = Vector2.Distance(potentialPlayerTargets[i].transform.position, transform.position) < chaseDistance;
            bool playerIsAlive = potentialPlayerTargets[i].GetComponent<Health>().GetCurrentHealth() > 0;
            
            if (isWithinChaseDist && playerIsAlive)
            {
                validPlayerTargets.Add(potentialPlayerTargets[i]);
            }
        }

        if (validPlayerTargets.Count > 0)
        {
            Transform closestPlayer = validPlayerTargets[0].transform;
            float distance = Vector3.Distance(transform.position, closestPlayer.position);

            for (int i = 1; i < validPlayerTargets.Count; i++)
            {
                float nextDistance = Vector3.Distance(transform.position, validPlayerTargets[i].transform.position);
                if (nextDistance < distance)
                {
                    closestPlayer = validPlayerTargets[i].transform;
                    distance = nextDistance;
                }
            }

            path.destination = closestPlayer.position;
            //headedToWaypoint = false;
        }
        /*else
        {
            if (Vector2.Distance(transform.position, targetWaypoint.position) < waypointArrivalDist)
            {
                headedToWaypoint = false;
            }
            if (!headedToWaypoint)
            {
                HeadToRandomWaypoint();
            }
        }*/
    }

    /*private void HeadToRandomWaypoint()
    {
        headedToWaypoint = true;
        int rand = UnityEngine.Random.Range(0, waypoints.Length);
        targetWaypoint = waypoints[rand].transform;
        path.destination = targetWaypoint.position;
    }*/

    private void HeadToNearbySpot()
    {
        float randX = UnityEngine.Random.Range(-3f, 3f);
        float randY = UnityEngine.Random.Range(-3f, 3f);
        Vector3 randCoord = new Vector3(randX, randY);
        path.destination = transform.position - randCoord;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
        Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, waypointArrivalDist);
    }
}
