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
    [SerializeField] GameObject pauseScreen;

    private TrackLivingPlayers trackLivingPlayers;
    private KillCounter killCounter;
    private GameTimer gameTimer;
    [SerializeField] public UpdateHUDStats hudStats;

    private float sceneLoadDelay = 4.0f;

    private CyclePlayer cyclePlayer;

    [SerializeField] ShowCharacterStats charStats;

    private bool isPaused = false;

    PlayerControls controls;

    [SerializeField] CameraShake cameraShake;

    private void Awake()
    {
        SingletonPattern();
        objectives = GetComponent<Objectives>();
        trackLivingPlayers = GetComponent<TrackLivingPlayers>();
        killCounter = GetComponent<KillCounter>();
        gameTimer = GetComponent<GameTimer>();
        cyclePlayer = GetComponent<CyclePlayer>();
        pauseScreen.SetActive(false);

        controls = new PlayerControls();

        controls.DefaultActionMap.Pause.performed += ctx => TogglePause();
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
        cyclePlayer.enabled = false;
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSFXLoop("CharRun");
        AudioManager.Instance.PlaySFX("Win");
        victoryScreen.SetActive(true);
        victoryScreen.GetComponent<DisplayEndStats>().DisplayStats(GetNumLivingPlayers(), GetKillCount(), GetElapsedTimeStamp());
        Invoke("LoadNextLevel", sceneLoadDelay);
        FindObjectOfType<TriggerSelfDestruct>().Stop();
    }

    private void Lose()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSFXLoop("CharRun");
        AudioManager.Instance.PlaySFX("Lose");
        defeatScreen.SetActive(true);
        Invoke("RestartLevel", sceneLoadDelay);
        FindObjectOfType<TriggerSelfDestruct>().Stop();
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

    public GameObject[] GetPlayers()
    {
        Movement[] movements = cyclePlayer.GetPlayerCharacters();
        GameObject[] objects = new GameObject[movements.Length];
        for (int i = 0; i < movements.Length; i++)
        {
            objects[i] = movements[i].gameObject;
        }
        return objects;
    }

    public void UpdatePlayerHPDisplay(int player, int hp)
    {
        charStats.UpdatePlayerHP(player, hp);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(isPaused);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(isPaused);
        }
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }

    public void ShakeCamera(float amount)
    {
        cameraShake.AddShake(amount);
    }

    private void OnEnable()
    {
        controls.DefaultActionMap.Enable();
    }

    private void OnDisable()
    {
        controls.DefaultActionMap.Disable();
    }
}
