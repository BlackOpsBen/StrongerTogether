using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustRange : MonoBehaviour
{
    [SerializeField] float rangeSpeed = 5.0f;
    [SerializeField] CircleCollider2D circleCollider;
    [SerializeField] TargetEnemies targetEnemies;
    private Movement movement;

    private void Start()
    {
        movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        float range;
        if (movement.GetIsMoving())
        {
            range = targetEnemies.weapon.GetRangeWhileMoving();
        }
        else
        {
            range = targetEnemies.weapon.GetRange();
        }
        circleCollider.radius = Mathf.Lerp(circleCollider.radius, range, Time.deltaTime * rangeSpeed);
    }
}
