using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] AIPath path;
    [SerializeField] Animator animator;

    private void Update()
    {
        animator.SetFloat("Horizontal", path.desiredVelocity.x);
        animator.SetFloat("Vertical", path.desiredVelocity.y);
        if (path.desiredVelocity.magnitude > float.Epsilon)
        {
            animator.SetBool("isMoving", true);
        }
    }
}
