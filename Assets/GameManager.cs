using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Objectives objectives;

    private void Awake()
    {
        SingletonPattern();
        objectives = GetComponent<Objectives>();
    }

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public Objectives GetObjectives()
    {
        return objectives;
    }

    public void EndGame(bool win)
    {
        Debug.Log("MISSION ACCOMPLISHED!");
    }
}
