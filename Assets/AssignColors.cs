using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignColors : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController[] animatorControllers;

    private CyclePlayer cycler;

    private void Start()
    {
        cycler = FindObjectOfType<CyclePlayer>();

        for (int i = 0; i < animatorControllers.Length; i++)
        {
            cycler.GetPlayerAnimator(i).runtimeAnimatorController = animatorControllers[i];
        }
    }
}
