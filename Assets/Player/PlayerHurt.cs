using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour, IHurt
{
    private PFXPool hitPFXPool;

    private void Start()
    {
        hitPFXPool = FindObjectOfType<PFXPool>();
    }

    public void TriggerHurtBehavior()
    {
        AudioManager.Instance.PlayDialog(int.Parse(gameObject.name), AudioManager.DIALOG_HURT, false);
        hitPFXPool.SpawnNextInPool(transform.position);
        GameManager.Instance.UpdatePlayerHPDisplay(int.Parse(gameObject.name), GetComponent<Health>().GetCurrentHealth());
    }
}
