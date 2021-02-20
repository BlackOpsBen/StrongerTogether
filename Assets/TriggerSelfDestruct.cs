using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TriggerSelfDestruct : MonoBehaviour, ITriggerEffect
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Image pulse;
    [SerializeField] float textStartAlpha;
    [SerializeField] float textEndAlpha;
    [SerializeField] float pulseStartAlpha;
    [SerializeField] float pulseEndAlpha;

    private float currentPulse = 0f;

    [SerializeField] float startTime = 120f;
    private float currentTime;
    float currentTimeNormalized;

    private bool isStarted = false;

    private bool isFinished = false;

    private void Start()
    {
        currentTime = startTime;
        pulse.color = new Color(pulse.color.r, pulse.color.g, pulse.color.b, 0f);
        timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, 0f);
    }

    private void Update()
    {
        if (isStarted && !isFinished)
        {
            currentTime -= Time.deltaTime;
            timerText.text = GetTimeStamp();
            UpdatePulse();
        }

        if (currentTime < float.Epsilon && !isFinished)
        {
            Destruct();
            isFinished = true;
        }
    }

    private void UpdatePulse()
    {
        currentTimeNormalized = Mathf.InverseLerp(startTime, 0f, currentTime);
        currentPulse = Mathf.Lerp(pulseStartAlpha, pulseEndAlpha, currentTimeNormalized);

        pulse.color = new Color(pulse.color.r, pulse.color.g, pulse.color.b, currentPulse);
        timerText.color = new Color(pulse.color.r, pulse.color.g, pulse.color.b, currentPulse);
    }

    private void Destruct()
    {
        AudioManager.Instance.StopSFXLoop("Alarm");
        AudioManager.Instance.PlaySFX("Explosion");
        GameManager.Instance.EndGame(false);
        timerText.gameObject.SetActive(false);
    }

    public string GetTimeStamp()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime) - (minutes * 60);
        int centiseconds = Mathf.FloorToInt(currentTime * 100f) - (minutes * 6000) - (seconds * 100);
        return string.Format("{0}:{1}:{2}", minutes.ToString("D2"), seconds.ToString("D2"), centiseconds.ToString("D2"));
    }

    public void Trigger()
    {
        isStarted = true;
        AudioManager.Instance.PlaySFXLoop("Alarm");
    }
}
