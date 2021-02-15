using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void ModifyHealth(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Min(maxHP, currentHP);
        if (currentHP < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
