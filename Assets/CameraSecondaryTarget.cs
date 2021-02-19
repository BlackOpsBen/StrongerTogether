using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecondaryTarget : MonoBehaviour
{
    [SerializeField] Transform secondaryTarget;

    public Transform GetSecondaryTarget()
    {
        return secondaryTarget;
    }
}
