using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSplat : MonoBehaviour
{
    [SerializeField] Sprite[] spriteOptions;
    [SerializeField] SpriteRenderer sr;

    private void Start()
    {
        int rand = UnityEngine.Random.Range(0, spriteOptions.Length);
        sr.sprite = spriteOptions[rand];
    }
}
