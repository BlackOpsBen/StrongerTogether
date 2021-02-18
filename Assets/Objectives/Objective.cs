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
        Debug.LogWarning("Objective being marked Complete");
        isComplete = true;
    }

    public bool GetIsComplete()
    {
        Debug.Log("GetIsComplete called. Returning: " + isComplete.ToString());
        return isComplete;
    }
}
