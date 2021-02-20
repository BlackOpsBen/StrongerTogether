using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletesObjective : MonoBehaviour, IInteract
{
    [SerializeField] Objective completesObjective;
    private ITriggerEffect optionalTriggerOnComplete;
    private InteractionTimer timer;

    [SerializeField] string interactionSoundName;

    [SerializeField] GameObject prereqReminderUI;
    private RectTransform rect;
    private FadeOutText fade;

    [SerializeField] SpriteRenderer[] spritesToChange;
    [SerializeField] Sprite[] to;

    private void Start()
    {
        timer = GetComponent<InteractionTimer>();
        if (prereqReminderUI != null)
        {
            rect = prereqReminderUI.GetComponent<RectTransform>();
            fade = prereqReminderUI.GetComponent<FadeOutText>();
        }

        optionalTriggerOnComplete = GetComponent<ITriggerEffect>();
    }

    public void Interact(float speedMultiplier)
    {
        if (CheckPrereqsComplete())
        {
            bool alreadyComplete = GameManager.Instance.GetObjectives().GetObjective(completesObjective).GetIsComplete();
            if (!alreadyComplete)
            {
                if (timer.GetProgress() < 1.0f)
                {
                    timer.MakeProgress(speedMultiplier);

                    if (interactionSoundName != "")
                    {
                        AudioManager.Instance.PlaySFXLoop(interactionSoundName);
                    }

                    return;
                }
                else
                {
                    CompleteInteraction();
                }
            }
        }
        else if (prereqReminderUI != null)
        {
            DisplayReminder();
        }
        
    }

    private void CompleteInteraction()
    {
        if (interactionSoundName != "")
        {
            AudioManager.Instance.StopSFXLoop(interactionSoundName);
        }

        GameManager.Instance.GetObjectives().CompleteObjective(completesObjective);
        timer.ResetProgress();

        ChangeSprites();

        if (optionalTriggerOnComplete != null)
        {
            optionalTriggerOnComplete.Trigger();
        }
    }

    private void ChangeSprites()
    {
        for (int i = 0; i < spritesToChange.Length; i++)
        {
            if (to[i] != null)
            {
                spritesToChange[i].sprite = to[i];
            }
        }
    }

    private bool CheckPrereqsComplete()
    {
        for (int i = 0; i < completesObjective.prereqObjectives.Length; i++)
        {
            if (!GameManager.Instance.GetObjectives().GetObjectives()[i].GetIsComplete())
            {
                return false;
            }
        }
        return true;
    }

    private void DisplayReminder()
    {
        rect.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        fade.DisplayText();
        AudioManager.Instance.PlayObjectiveReminder();
    }

    public void EndInteract()
    {
        if (interactionSoundName != "")
        {
            AudioManager.Instance.StopSFXLoop(interactionSoundName);
        }
    }
}
