using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour, IHurt
{
    private PFXPool hitPFXPool;

    private void Start()
    {
        hitPFXPool = FindObjectOfType<PFXManager>().GetHitPool();
    }

    public void TriggerHurtBehavior()
    {
        AudioManager.Instance.PlayDialog(int.Parse(gameObject.name), AudioManager.DIALOG_HURT, false);
        hitPFXPool.SpawnNextInPlayerPool(transform.position + Vector3.up);
        GameManager.Instance.UpdatePlayerHPDisplay(int.Parse(gameObject.name), GetComponent<Health>().GetCurrentHealth());
    }
}
