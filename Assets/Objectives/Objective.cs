using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Objective : ScriptableObject
{
    public string text;
    private bool isComplete = false;

    public void Complete()
    {
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
