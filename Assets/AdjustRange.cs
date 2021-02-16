using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustRange : MonoBehaviour
{
    [SerializeField] float rangeSpeed = 5.0f;
    [SerializeField] CircleCollider2D circleCollider;
    //[SerializeField] TargetEnemies targetEnemies;
    private Weapon weapon;
    private Movement movement;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        float range;
        if (movement.GetIsMoving())
        {
            range = weapon.GetWeaponTemplate().GetRangeWhileMoving();
        }
        else
        {
            range = weapon.GetWeaponTemplate().GetRange();
        }
        circleCollider.radius = Mathf.Lerp(circleCollider.radius, range, Time.deltaTime * rangeSpeed);
    }
}
