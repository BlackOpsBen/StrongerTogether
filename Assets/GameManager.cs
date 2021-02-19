using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Objectives objectives;

    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject defeatScreen;

    private TrackLivingPlayers trackLivingPlayers;
    private KillCounter killCounter;
    private GameTimer gameTimer;
    [SerializeField] public UpdateHUDStats hudStats;

    private float sceneLoadDelay = 4.0f;

    private void Awake()
    {
        SingletonPattern();
        objectives = GetComponent<Objectives>();
        trackLivingPlayers = GetComponent<TrackLivingPlayers>();
        killCounter = GetComponent<KillCounter>();
        gameTimer = GetComponent<GameTimer>();
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
        victoryScreen.SetActive(true);
        victoryScreen.GetComponent<DisplayEndStats>().DisplayStats(GetNumLivingPlayers(), GetKillCount(), GetElapsedTimeStamp());
        Invoke("LoadNextLevel", sceneLoadDelay);
    }

    private void Lose()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSFXLoop("CharRun");
        AudioManager.Instance.PlaySFX("Lose");
        defeatScreen.SetActive(true);
        Invoke("RestartLevel", sceneLoadDelay);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextLevel()
    {
        int sceneCount = SceneManager.sceneCount;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        nextScene = nextScene % sceneCount;
        SceneManager.LoadScene(nextScene);
    }

    public int GetNumLivingPlayers()
    {
        return trackLivingPlayers.GetNumLivingPlayers();
    }

    public int GetKillCount()
    {
        return killCounter.GetKillCount();
    }

    public void IncreaseKillCount()
    {
        killCounter.AddKill();
        hudStats.UpdateKills(killCounter.GetKillCount());
    }

    public string GetElapsedTimeStamp()
    {
        return gameTimer.GetTimeStamp();
    }
}
