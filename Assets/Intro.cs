using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] Image black;

    private float fadeSpeed = .5f;

    private void Start()
    {
        black.color = Color.black;

        // TODO play objectives dialog, high priority
    }

    private void Update()
    {
        float newAlpha = black.color.a - Time.deltaTime * fadeSpeed;
        if (newAlpha < 0f)
        {
            FadeIn(newAlpha);
            gameObject.SetActive(false);

        }
        FadeIn(newAlpha);
    }

    private void FadeIn(float newAlpha)
    {
        black.color = new Color(black.color.r, black.color.g, black.color.b, newAlpha);
    }
}
