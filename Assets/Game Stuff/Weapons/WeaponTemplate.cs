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
    [SerializeField] Sprite icon;
    [SerializeField] SoundCue soundCue;

    //private bool isReady = true;
    //private float reloadTimer;

    /*public float GetReloadTimer()
    {
        return reloadTimer;
    }*/

    /*public void SetReloadTimer(float newValue)
    {
        reloadTimer = newValue;
    }*/

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

    /*public void SetIsReady(bool value)
    {
        isReady = value;
    }*/

    /*public bool GetIsReady()
    {
        return isReady;
    }*/

    public int GetDamage()
    {
        return damage;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetSoundCueName()
    {
        return soundCue.name;
    }
}
