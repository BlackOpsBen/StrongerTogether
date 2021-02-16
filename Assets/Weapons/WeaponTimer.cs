using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTimer : MonoBehaviour
{
    private Weapon weapon;
    private float rateOfFireRPS;
    private float interval;
    private float reloadTimer;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        rateOfFireRPS = weapon.GetWeaponTemplate().GetRateOfFire();
        interval = 1 / rateOfFireRPS;
        reloadTimer = interval;
        weapon.GetWeaponTemplate().SetReloadTimer(reloadTimer);
    }

    private void Update()
    {
        reloadTimer = weapon.GetWeaponTemplate().GetReloadTimer();

        if (reloadTimer < interval)
        {
            weapon.GetWeaponTemplate().SetReloadTimer(reloadTimer += Time.deltaTime);
        }
        else
        {
            weapon.GetWeaponTemplate().SetIsReady(true);
        }
    }
}
