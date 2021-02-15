using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRange : MonoBehaviour
{
    private float range = 3.0f;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.right * range, Color.red);
    }
}
