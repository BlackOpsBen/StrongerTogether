using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] int maxSpawn = 50;

    [SerializeField] List<GameObject> waitingPool = new List<GameObject>();
    [SerializeField] List<GameObject> livingPool = new List<GameObject>();

    private float spawnCountdown = 0f;

    private float minInterval = .2f;

    private float maxInterval = 10f;

    private float spawnIntensity = 1f;

    private void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown < float.Epsilon)
        {
            Spawn();
            ResetCountdown();
        }
    }

    private void ResetCountdown()
    {
        spawnCountdown = UnityEngine.Random.Range(minInterval, maxInterval / spawnIntensity);
    }

    private void Spawn()
    {
        if (waitingPool.Count > 0)
        {
            GameObject obj = waitingPool[0];
            livingPool.Add(obj);
            waitingPool.RemoveAt(0);
            ResetEnemy(obj);
        }
        else
        {
            if (livingPool.Count < maxSpawn)
            {
                livingPool.Add(InstantiateNewEnemy());
            }
        }
    }

    private void ResetEnemy(GameObject enemy)
    {
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }

    private GameObject InstantiateNewEnemy()
    {
        return Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
    }
}
