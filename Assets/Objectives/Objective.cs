using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Objective : ScriptableObject
{
    public string text;
    private bool isComplete = false;
    public Objective[] prereqObjectives;
    public string optionalCompletionSFX;

    public void Complete()
    {
        if (optionalCompletionSFX != "")
        {
            AudioManager.Instance.PlaySFX(optionalCompletionSFX);
        }
        isComplete = true;
    }

    public bool GetIsComplete()
    {
        return isComplete;
    }

    public void Initialize()
    {
        isComplete = false;
    }
}
