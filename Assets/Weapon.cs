using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponTemplate equippedWeapon;
    [SerializeField] GameObject muzzleFlash;

    public void PullTrigger(Transform target)
    {
        if (equippedWeapon.GetIsReady())
        {
            FireShot(target);
            equippedWeapon.SetIsReady(false);
            equippedWeapon.SetReloadTimer(0.0f);
        }
    }

    private void FireShot(Transform target)
    {
        DealDamage(target);

        AudioManager.Instance.PlaySFX(equippedWeapon.name);

        ShowMuzzleFlash();
    }

    private void DealDamage(Transform target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.ModifyHealth(-equippedWeapon.GetDamage());
        }
    }

    private void ShowMuzzleFlash()
    {

    }

    /*public float GetFiringArc()
    {
        return equippedWeapon.GetFiringArc();
    }

    public float GetRange()
    {
        return equippedWeapon.GetRange();
    }

    public float GetRateOfFire()
    {
        return equippedWeapon.GetRateOfFire();
    }*/

    public WeaponTemplate GetWeaponTemplate()
    {
        return equippedWeapon;
    }
}
