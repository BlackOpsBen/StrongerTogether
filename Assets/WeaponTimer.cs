using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTimer : MonoBehaviour
{
    private WeaponTemplate weapon;
    private float rateOfFireRPS;
    private float interval;
    private float reloadTimer;

    private void Start()
    {
        weapon = GetComponent<TargetEnemies>().weapon;
        rateOfFireRPS = weapon.GetRateOfFire();
        interval = 1 / rateOfFireRPS;
        reloadTimer = interval;
        weapon.SetReloadTimer(reloadTimer);
    }

    private void Update()
    {
        reloadTimer = weapon.GetReloadTimer();

        if (reloadTimer < interval)
        {
            weapon.SetReloadTimer(reloadTimer += Time.deltaTime);
        }
        else
        {
            weapon.SetIsReady(true);
        }
    }
}
