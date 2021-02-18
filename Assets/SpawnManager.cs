using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Spawner[] spawners;

    private void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
    }

    private void Update()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].SetIsValidSpawn(CheckIfOffScreen(spawners[i].transform.position));
        }
    }

    private bool CheckIfOffScreen(Vector3 pos)
    {
        Vector2 screenPos = Camera.main.WorldToViewportPoint(pos);
        return (screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1);
    }
}
