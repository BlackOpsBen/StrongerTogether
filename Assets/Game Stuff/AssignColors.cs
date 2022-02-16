using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignColors : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController[] animatorControllers;

    public void AssignColorAnimator(Animator[] animators)
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].runtimeAnimatorController = animatorControllers[i];
        }
    }
}
