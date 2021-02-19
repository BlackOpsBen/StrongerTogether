using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public const int DIALOG_SELECTED = 0;
    public const int DIALOG_KILL = 1;
    public const int DIALOG_HURT = 2;
    public const int DIALOG_DEAD = 3;

    public static AudioManager Instance { get; private set; }

    [Header("SFX")]
    public Sound[] SFX;

    [Header("Characters")]
    public SoundGroup[] characterSoundGroups;

    [Header("Music")]
    [SerializeField] AudioSource musicAudioSource;

    private bool someoneIsSpeaking = false;
    private float speakingDuration = 0f;

    private DialogLimiter dialogLimiter;

    private void Awake()
    {
        dialogLimiter = GetComponent<DialogLimiter>();
        SingletonPattern();
        CreateAudioSources(ref SFX);
        for (int i = 0; i < characterSoundGroups.Length; i++)
        {
            //CreateAudioSources(ref characterSoundGroups[i].selected);
            for (int j = 0; j < characterSoundGroups[i].dialogCategories.Length; j++)
            {
                for (int k = 0; k < characterSoundGroups[i].dialogCategories[j].dialogsOptions.Length; k++)
                {

                }
            }
        }
        foreach (SoundGroup sg in characterSoundGroups)
        {
            foreach (DialogCategory dc in sg.dialogCategories)
            {
                CreateAudioSources(ref dc.dialogsOptions);
            }
        }
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

    private void Update()
    {
        if (speakingDuration < 0.0f)
        {
            someoneIsSpeaking = false;
        }
        else
        {
            speakingDuration -= Time.deltaTime;
        }
    }

    private void CreateAudioSources(ref Sound[] sounds)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.Play();
    }

    public void PlaySFXLoop(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.loop = true;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void StopSFXLoop(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.loop = false;
        s.source.Stop();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void PlayDialog(int playerIndex, int DIALOG_CATEGORY, bool oneAtATime)
    {
        int maxOption = characterSoundGroups[playerIndex].dialogCategories[DIALOG_CATEGORY].dialogsOptions.Length;
        int selectedOption = UnityEngine.Random.Range(0, maxOption);
        Sound s = characterSoundGroups[playerIndex].dialogCategories[DIALOG_CATEGORY].dialogsOptions[selectedOption];

        if (oneAtATime)
        {
            if (someoneIsSpeaking || !dialogLimiter.GetCanSpeak(playerIndex))
            {
                return;
            }
            speakingDuration = s.source.clip.length;
            someoneIsSpeaking = true;
            dialogLimiter.SetCanSpeak(playerIndex, false);
        }

        s.source.Play();
    }

    public bool GetIsSomeoneSpeaking()
    {
        return someoneIsSpeaking;
    }
}

[System.Serializable]
public class SoundGroup
{
    public string name;
    public DialogCategory[] dialogCategories;
}

[System.Serializable]
public class DialogCategory
{
    public string name;
    public Sound[] dialogsOptions;
}
