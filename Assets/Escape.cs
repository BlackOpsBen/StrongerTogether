using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToDisableOnEscape;

    private CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void DoEscape()
    {
        DisableObjects();
        DisableColliders();
        DisableMovement();
    }

    private void DisableObjects()
    {
        for (int i = 0; i < objectsToDisableOnEscape.Length; i++)
        {
            objectsToDisableOnEscape[i].SetActive(false);
        }
    }

    private void DisableColliders()
    {
        circleCollider.enabled = false;
    }

    private void DisableMovement()
    {
        GetComponent<Movement>().SetIsActive(false);
    }
}
