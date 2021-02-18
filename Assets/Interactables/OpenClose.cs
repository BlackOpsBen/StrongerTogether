using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour, IInteract
{
    [SerializeField] Collider2D thisCollider;
    [SerializeField] Collider2D thatCollider;
    [SerializeField] bool startDisabled;
    [SerializeField] Sprite disabledState;
    [SerializeField] Sprite enabledState;

    private SpriteRenderer sr;

    private InteractionTimer timer;
    private bool isTimed = false;

    [SerializeField] string interactionSoundName;
    [SerializeField] string openCloseSoundName;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (startDisabled)
        {
            thisCollider.enabled = false;
            sr.sprite = disabledState;
        }
        else
        {
            sr.sprite = enabledState;
        }

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

                AudioManager.Instance.PlaySFXLoop(interactionSoundName);

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
        AudioManager.Instance.StopSFXLoop(interactionSoundName);
        AudioManager.Instance.PlaySFX(openCloseSoundName);

        thisCollider.enabled = !thisCollider.enabled;
        thatCollider.enabled = !thisCollider.enabled;
        ToggleSprite();
        thatCollider.GetComponent<OpenClose>().ToggleSprite();

        timer.ResetProgress();
    }

    public void ToggleSprite()
    {
        if (thisCollider.enabled)
        {
            sr.sprite = enabledState;
        }
        else
        {
            sr.sprite = disabledState;
        }
    }

    public void EndInteract()
    {
        AudioManager.Instance.StopSFXLoop(interactionSoundName);
    }
}
