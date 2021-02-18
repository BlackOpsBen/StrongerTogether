using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendSignal : MonoBehaviour, IInteract
{
    [SerializeField] Objective completesObjective;
    private InteractionTimer timer;

    private void Start()
    {
        timer = GetComponent<InteractionTimer>();
    }

    public void Interact(float speedMultiplier)
    {
        bool alreadyComplete = GameManager.Instance.GetObjectives().GetObjective(completesObjective).GetIsComplete();
        Debug.Log("already complete? " + alreadyComplete.ToString());
        if (!alreadyComplete)
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
    }

    private void CompleteInteraction()
    {
        GameManager.Instance.GetObjectives().CompleteObjective(completesObjective);
        timer.ResetProgress();
    }
}
