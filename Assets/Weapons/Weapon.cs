using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponTemplate equippedWeapon;
    [SerializeField] Light2D[] muzzleFlashLights;
    [SerializeField] SpriteRenderer[] muzzleFlashSprites;
    [SerializeField] DrawBulletTrail bulletTrail;

    private float flashIntensity = 0.0f;
    private float flashSpeed = 10f;

    private WeaponTimer weaponTimer;

    private void Awake()
    {
        weaponTimer = GetComponent<WeaponTimer>();
        weaponTimer.InitializeROF(equippedWeapon.GetRateOfFire());
    }

    private void Update()
    {
        DimMuzzleFlash();
    }

    public void PullTrigger(Transform target)
    {
        /*if (equippedWeapon.GetIsReady())
        {
            FireShot(target);
            equippedWeapon.SetIsReady(false);
            //equippedWeapon.SetReloadTimer(0.0f);
            weaponTimer.Reset();
        }*/
        if (weaponTimer.GetIsReady())
        {
            FireShot(target);
            bulletTrail.Draw(target.position);
            weaponTimer.Reset();
        }
    }

    private void FireShot(Transform target)
    {
        DealDamage(target);

        AudioManager.Instance.PlaySFX(equippedWeapon.name);
        int currentPlayerIndex = int.Parse(transform.parent.name);

        AudioManager.Instance.PlayDialog(currentPlayerIndex, AudioManager.DIALOG_KILL, true);

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
        flashIntensity = 1.0f;
    }

    private void DimMuzzleFlash()
    {
        if (flashIntensity > 0.0f)
        {
            flashIntensity -= Time.deltaTime * flashSpeed;
            flashIntensity = Mathf.Clamp(flashIntensity, 0.0f, 1.0f);
        }

        /*for (int i = 0; i < muzzleFlashLights.Length; i++)
        {
            muzzleFlashLights[i].intensity = flashIntensity;
        }*/

        for (int i = 0; i < muzzleFlashSprites.Length; i++)
        {
            muzzleFlashSprites[i].color = new Color(muzzleFlashSprites[i].color.r, muzzleFlashSprites[i].color.g, muzzleFlashSprites[i].color.b, flashIntensity);
        }
    }

    public WeaponTemplate GetWeaponTemplate()
    {
        return equippedWeapon;
    }
}
