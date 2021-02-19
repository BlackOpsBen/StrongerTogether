using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float elapsedTimeSeconds = 0.0f;

    private void Update()
    {
        elapsedTimeSeconds += Time.deltaTime;
        GameManager.Instance.hudStats.UpdateTime(GetTimeStamp());
    }

    public string GetTimeStamp()
    {
        int minutes = Mathf.FloorToInt(elapsedTimeSeconds / 60f);
        int seconds = Mathf.FloorToInt(elapsedTimeSeconds) - (minutes * 60);
        int deciseconds = Mathf.FloorToInt(elapsedTimeSeconds * 10f) - (minutes * 600) - (seconds * 10);
        return string.Format("{0}m {1}.{2}s", minutes.ToString(), seconds.ToString(), deciseconds.ToString());
    }
}
