using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemies : MonoBehaviour
{
    [SerializeField] WeaponTemplate weapon;

    CircleCollider2D circleCollider;

    public List<Transform> targets = new List<Transform>();

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Target"))
        {
            targets.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targets.Contains(collision.transform))
        {
            targets.Remove(collision.transform);
        }
    }

    public void FireWeapon()
    {
        weapon.Shoot();
    }
}
