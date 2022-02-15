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
            // TODO play optionalCompletionSFX sound
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
