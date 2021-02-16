using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("SFX")]
    public Sound[] SFX;

    [Header("Characters")]
    public SoundGroup[] characterSounds;

    private void Awake()
    {
        SingletonPattern();
        CreateAudioSources(ref SFX);
        for (int i = 0; i < characterSounds.Length; i++)
        {
            CreateAudioSources(ref characterSounds[i].selected);
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
}

[System.Serializable]
public class SoundGroup
{
    public string name;
    public Sound[] selected;
    public Sound[] shooting;
    public Sound[] hurt;
    public Sound[] dying;
}
