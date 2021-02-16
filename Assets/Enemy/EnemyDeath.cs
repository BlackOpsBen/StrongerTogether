using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour, IDie
{
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
