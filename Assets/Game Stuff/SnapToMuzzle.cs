using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToMuzzle : MonoBehaviour
{
    [SerializeField] Transform muzzle;

    private void Update()
    {
        transform.position = muzzle.position;
    }
}
