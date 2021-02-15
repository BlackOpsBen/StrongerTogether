using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRange : MonoBehaviour
{
    private TargetEnemies targetEnemies;

    private void Start()
    {
        targetEnemies = GetComponent<TargetEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.right * targetEnemies.weapon.GetRange(), Color.red);
    }
}
