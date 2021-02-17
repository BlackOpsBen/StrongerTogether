using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] float interactionMultiplier = 1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        IInteract interactable = collision.gameObject.GetComponent<IInteract>();
        if (interactable != null)
        {
            Debug.Log(transform.parent.name + " is interacting with " + collision.name);
            interactable.Interact(interactionMultiplier);
        }
    }
}
