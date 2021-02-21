using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour, IHurt
{
    private PFXPool hitPFXPool;

    private void Start()
    {
        hitPFXPool = FindObjectOfType<PFXManager>().GetHitPool();
    }

    public void TriggerHurtBehavior()
    {
        AudioManager.Instance.PlayDialog(4, AudioManager.DIALOG_SELECTED, false); // TODO make not play 100%
        hitPFXPool.SpawnNextInEnemyPool(transform.position + Vector3.up);
        RandomlyDropBloodSplat();
    }

    private void RandomlyDropBloodSplat()
    {
        int rand = UnityEngine.Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.Instance.DropBloodSplat(transform.position);
        }
    }
}
