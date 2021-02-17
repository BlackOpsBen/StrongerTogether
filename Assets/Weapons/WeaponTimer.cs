using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTimer : MonoBehaviour
{
    //private Weapon weapon;
    public float rateOfFireRPS;
    public float interval;
    public float reloadTimer;

    private void Start()
    {
        //weapon = GetComponent<Weapon>();
        //rateOfFireRPS = weapon.GetWeaponTemplate().GetRateOfFire();
        interval = 1 / rateOfFireRPS;
        reloadTimer = interval;
        //weapon.GetWeaponTemplate().SetReloadTimer(reloadTimer);
    }

    private void Update()
    {
        //reloadTimer = weapon.GetWeaponTemplate().GetReloadTimer();

        if (!GetIsReady())
        {
            //weapon.GetWeaponTemplate().SetReloadTimer(reloadTimer += Time.deltaTime);
            reloadTimer += Time.deltaTime;
        }
        /*else
        {
            //weapon.GetWeaponTemplate().SetIsReady(true);
        }*/
    }

    public void InitializeROF(float rof)
    {
        rateOfFireRPS = rof;
    }

    public void Reset()
    {
        reloadTimer = 0.0f;
    }

    public bool GetIsReady()
    {
        return reloadTimer > interval;
    }
}
