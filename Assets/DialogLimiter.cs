using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLimiter : MonoBehaviour
{
    private float[] timers = new float[4];
    private float interval = 10f;

    private void Start()
    {
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] = 0.0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] -= Time.deltaTime;
        }
    }

    public bool GetCanSpeak(int playerIndex)
    {
        if (timers[playerIndex] < 0.0f)
        {
            return true;
        }
        return false;
    }
}
