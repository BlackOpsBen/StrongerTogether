using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponTemplate : ScriptableObject
{
    [SerializeField] float range;
    [SerializeField] float rangeWhileMoving;
    [SerializeField] float firingArc;
    [SerializeField] float rateOfFireRPS;
    [SerializeField] int damage;

    private bool isReady = true;
    private float reloadTimer;

    public float GetReloadTimer()
    {
        return reloadTimer;
    }

    public void SetReloadTimer(float newValue)
    {
        reloadTimer = newValue;
    }

    public float GetFiringArc()
    {
        return firingArc;
    }

    public float GetRange()
    {
        return range;
    }

    public float GetRangeWhileMoving()
    {
        return rangeWhileMoving;
    }

    public float GetRateOfFire()
    {
        return rateOfFireRPS;
    }

    public void PullTrigger(Transform target)
    {
        if (isReady)
        {
            FireShot(target);
            isReady = false;
            SetReloadTimer(0.0f);
        }
    }

    private void FireShot(Transform target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.ModifyHealth(-damage);
        }

        AudioManager.Instance.PlaySFX(name);
    }

    public void SetIsReady(bool value)
    {
        isReady = value;
    }
}
