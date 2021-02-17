using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    [SerializeField] Animator spriteAnimator;
    [SerializeField] Animator muzzlePosAnimator;
    [SerializeField] Transform facingTarget;
    private Movement movement;

    private Vector2[] vectors =
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(-1, 0),
        new Vector2(1, 0)
    };

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Vector2 vector = facingTarget.position - transform.position;
        UpdateSpriteAnimator(vector);
        UpdateMuzzleAnimator(vector);
    }

    private void UpdateSpriteAnimator(Vector2 vector)
    {
        spriteAnimator.SetFloat("Horizontal", vector.x);
        spriteAnimator.SetFloat("Vertical", vector.y);
        spriteAnimator.SetBool("isMoving", movement.GetIsMoving());
    }

    private void UpdateMuzzleAnimator(Vector2 vector)
    {
        int nearestVectorIndex = 0;
        float distance = Vector2.Distance(vector, vectors[nearestVectorIndex]);

        for (int i = 1; i < vectors.Length; i++)
        {
            float testDistance = Vector2.Distance(vector, vectors[i]);
            if (testDistance < distance)
            {
                nearestVectorIndex = i;
                distance = testDistance;
            }
        }

        muzzlePosAnimator.SetFloat("Horizontal", vectors[nearestVectorIndex].x);
        muzzlePosAnimator.SetFloat("Vertical", vectors[nearestVectorIndex].y);
    }
}
