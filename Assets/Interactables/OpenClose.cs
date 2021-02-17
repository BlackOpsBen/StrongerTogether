using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour, IInteract
{
    [SerializeField] Collider2D closedCollider;

    private InteractionTimer timer;
    private bool isTimed = false;

    private void Awake()
    {
        timer = GetComponent<InteractionTimer>();
        if (timer != null)
        {
            isTimed = true;
        }
    }

    public void Interact(float speedMultiplier)
    {
        if (isTimed)
        {
            if (timer.GetProgress() < 1.0f)
            {
                timer.MakeProgress(speedMultiplier);
                return;
            }
            else
            {
                CompleteInteraction();
            }
        }
        else
        {
            CompleteInteraction();
        }
    }

    private void CompleteInteraction()
    {
        Debug.LogWarning("Toggling door collider");
        closedCollider.enabled = !closedCollider.enabled;
    }
}
