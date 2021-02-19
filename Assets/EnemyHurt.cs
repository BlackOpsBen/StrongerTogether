using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour, IHurt
{
    [SerializeField] ParticleSystem hitPFX;

    public void TriggerHurtBehavior()
    {
        hitPFX.Play();
    }
}
