using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int killCount = 0;

    public void AddKill()
    {
        killCount++;
    }

    public int GetKillCount()
    {
        return killCount;
    }
}
