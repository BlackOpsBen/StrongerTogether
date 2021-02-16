using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int attackDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health playerHealth = collision.collider.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.ModifyHealth(-attackDamage);

            if (playerHealth.GetCurrentHealth() > 0)
            {
                GetComponent<Health>().SetHealth(0);
            }
        }
    }
}
