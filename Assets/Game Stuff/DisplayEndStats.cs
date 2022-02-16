using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEndStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI values;

    public void DisplayStats(int survivors, int kills, string time)
    {
        values.text = survivors + "\n" + kills + "\n" + time;
    }
}
