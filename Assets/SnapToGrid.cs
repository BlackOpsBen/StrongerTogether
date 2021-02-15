using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class SnapToGrid : MonoBehaviour
{
    int gridSize = 10;
    private void Update()
    {
        Vector2Int gridPos = new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize), Mathf.RoundToInt(transform.position.y / gridSize));

        transform.position = new Vector3(
            gridPos.x * gridSize,
            gridPos.y * gridSize
        );
    }
}
