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
        if (win)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    private void Win()
    {
        Escape[] playersEscapes = FindObjectsOfType<Escape>();
        for (int i = 0; i < playersEscapes.Length; i++)
        {
            playersEscapes[i].DoEscape();
        }
        GetComponent<CyclePlayer>().enabled = false;
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSFXLoop("CharRun");
        AudioManager.Instance.PlaySFX("Win");
    }

    private void Lose()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSFXLoop("CharRun");
        AudioManager.Instance.PlaySFX("Lose");
    }
}
