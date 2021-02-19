using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHUDStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI kills;
    private string killsPrefix = "Kills: ";

    public void UpdateKills(int numKills)
    {
        kills.text = killsPrefix + numKills;
    }

    public void UpdateTime(string timestamp)
    {
        time.text = timestamp;
    }
}
