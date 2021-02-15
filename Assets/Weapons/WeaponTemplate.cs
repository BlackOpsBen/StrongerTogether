using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponTemplate : ScriptableObject
{
    [SerializeField] float range;
    [SerializeField] float firingArc;
    [SerializeField] float rateOfFire;
    [SerializeField] float damage;

    public float GetFiringArc()
    {
        return firingArc;
    }

    public float GetRange()
    {
        return range;
    }

    public void Shoot()
    {
        Debug.LogWarning(name + " fired!");
    }
}
