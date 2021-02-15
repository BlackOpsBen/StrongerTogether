using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    PlayerControls controls;

    [SerializeField] WeaponTemplate weapon;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    public void FireWeapon()
    {
        weapon.Shoot();
    }

    private void OnEnable()
    {
        controls.DefaultActionMap.Enable();
    }

    private void OnDisable()
    {
        controls.DefaultActionMap.Disable();
    }
}
