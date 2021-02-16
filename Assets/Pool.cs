using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] int maxPoolCount = 20;

    private GameObject[] pool;

    int nextUp = 0;

    private void Start()
    {
        pool = new GameObject[maxPoolCount];
    }

    public void GetNextInPool(Vector3 position)
    {
        if (pool[nextUp] != null)
        {
            Respawn(pool[nextUp], position);
        }
    }

    private void Respawn(GameObject item, Vector3 position)
    {
        item.transform.position = position;
        item.SetActive(true);
    }
}
