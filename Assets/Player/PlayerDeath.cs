using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDie
{
    [SerializeField] GameObject[] objectsToDisableOnDeath;

    [Header("Which player is this?")]

    private CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void Die()
    {
        DisableObjects();
        DisableColliders();
        SelectNextPlayer();
        AudioManager.Instance.PlayDialog(int.Parse(gameObject.name), AudioManager.DIALOG_DEAD, false);
        Debug.Log("gameObject.name as int is: " + int.Parse(gameObject.name));
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
