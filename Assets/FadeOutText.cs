using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOutText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private float fade = 1f;
    private float fadeSpeed = 5f;

    private void Update()
    {
        fade -= Time.deltaTime * fadeSpeed;
        Color updatedColor = new Color(text.color.r, text.color.g, text.color.b, fade);
        text.color = updatedColor;
    }

    public void DisplayText()
    {
        fade = 1f;
    }
}
