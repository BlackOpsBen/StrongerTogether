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

    private void Awake()
    {
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
        s.source.Play();
    }

    public void StopSFXLoop(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.loop = false;
        s.source.Stop();
    }

    public void PlayDialog(int activePlayerIndex, int DIALOG_CATEGORY)
    {
        int selectedOption = 0;
        Sound s = characterSoundGroups[activePlayerIndex].dialogCategories[DIALOG_CATEGORY].dialogsOptions[selectedOption];
        if (!s.source.isPlaying)
        {
            s.source.Play();
            Debug.Log("Played sound");
        }
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
