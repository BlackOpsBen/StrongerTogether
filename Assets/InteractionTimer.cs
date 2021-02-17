using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTimer : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite[] progressFrames;
    [SerializeField] float duration = 2.0f;
    private float timer = 0.0f;
    private bool isProgressing = false;

    private void Start()
    {
        sr.sprite = null;
    }

    private void Update()
    {
        if (!isProgressing)
        {
            timer -= Time.deltaTime;
        }

        isProgressing = false;

        timer = Mathf.Clamp(timer, 0.0f, duration);

        int progressFrameIndex = Mathf.CeilToInt(Mathf.Lerp(0f, progressFrames.Length-1, timer / duration));
        sr.sprite = progressFrames[progressFrameIndex];
    }

    public void MakeProgress(float multiplier)
    {
        timer += Time.deltaTime * multiplier;
        isProgressing = true;
    }

    public float GetProgress()
    {
        return timer / duration;
    }
}
