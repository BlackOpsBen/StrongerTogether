using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLivingPlayers : MonoBehaviour
{
    private int livingPlayers;

    private void Start()
    {
        livingPlayers = FindObjectsOfType<Movement>().Length;
    }

    public void ReduceLivingPlayers()
    {
        livingPlayers--;
        if (livingPlayers <= 0)
        {
            GameManager.Instance.EndGame(false);
        }
    }

    public int GetNumLivingPlayers()
    {
        return livingPlayers;
    }
}
