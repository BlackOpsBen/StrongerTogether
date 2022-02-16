using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFXManager : MonoBehaviour
{
    [SerializeField] PFXPool hitPool;
    [SerializeField] PFXPool deathPool;

    public PFXPool GetHitPool()
    {
        return hitPool;
    }

    public PFXPool GetDeathPool()
    {
        return deathPool;
    }
}
