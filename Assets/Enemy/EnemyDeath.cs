﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour, IDie
{
    private PFXPool deathPFXPool;

    private void Start()
    {
        deathPFXPool = FindObjectOfType<PFXManager>().GetDeathPool();
    }

    public void Die()
    {
        AudioManager.Instance.PlayDialog(4, AudioManager.DIALOG_DEAD, false); // TODO make not play 100%
        gameObject.SetActive(false);
        GameManager.Instance.IncreaseKillCount();
        deathPFXPool.SpawnNextInEnemyPool(transform.position + Vector3.up);
        RandomlyDropBody();
    }

    private void RandomlyDropBody()
    {
        int oddsMax = 3;
        int rand = UnityEngine.Random.Range(0, oddsMax);
        if (rand == 0)
        {
            GameManager.Instance.DropDeadBody(transform.position);
        }
    }
}
