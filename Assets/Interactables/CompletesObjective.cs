using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletesObjective : MonoBehaviour, IInteract
{
    [SerializeField] Objective completesObjective;
    private InteractionTimer timer;

    private void Start()
    {
        timer = GetComponent<InteractionTimer>();
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
                    return;
                }
                else
                {
                    CompleteInteraction();
                }
            }
        }
        else
        {
            DisplayReminder();
        }
        
    }

    private void CompleteInteraction()
    {
        GameManager.Instance.GetObjectives().CompleteObjective(completesObjective);
        timer.ResetProgress();
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
        Debug.LogWarning("Must complete other objectives first");
    }
}
