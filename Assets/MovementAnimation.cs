using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform facingTarget;
    private Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Vector2 vector = facingTarget.position - transform.position;
        UpdateAnimator(vector);
    }

    public void UpdateAnimator(Vector2 vector)
    {
        animator.SetFloat("Horizontal", vector.x);
        animator.SetFloat("Vertical", vector.y);
        animator.SetBool("isMoving", movement.GetIsMoving());
    }
}
