using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDie
{
    [SerializeField] GameObject[] objectsToDisableOnDeath;

    private CircleCollider2D circleCollider;

    private PFXPool deathPFXPool;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        deathPFXPool = FindObjectOfType<PFXManager>().GetDeathPool();
    }

    public void Die()
    {
        DisableObjects();
        DisableColliders();
        if (GetComponent<Movement>().GetIsActive())
        {
            SelectNextPlayer();
        }
        AudioManager.Instance.PlayDialog(int.Parse(gameObject.name), AudioManager.DIALOG_DEAD, false);
        GameManager.Instance.GetComponent<TrackLivingPlayers>().ReduceLivingPlayers();
        GameManager.Instance.UpdatePlayerHPDisplay(int.Parse(gameObject.name), GetComponent<Health>().GetCurrentHealth());
        deathPFXPool.SpawnNextInPlayerPool(transform.position + Vector3.up);
        GameManager.Instance.ShakeCamera(1f);
    }

    private void DisableObjects()
    {
        for (int i = 0; i < objectsToDisableOnDeath.Length; i++)
        {
            objectsToDisableOnDeath[i].SetActive(false);
        }
    }

    private void DisableColliders()
    {
        circleCollider.enabled = false;
    }

    private void SelectNextPlayer()
    {
        FindObjectOfType<CyclePlayer>().SelectNext();
    }
}
