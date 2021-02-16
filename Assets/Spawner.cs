using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] int maxSpawn = 50;

    List<GameObject> waitingPool = new List<GameObject>();
    List<GameObject> livingPool = new List<GameObject>();

    private void Spawn()
    {
        if (waitingPool.Count > 0)
        {
            GameObject obj = waitingPool[0];
            livingPool.Add(obj);
            waitingPool.RemoveAt(0);
            obj.transform.position = transform.position;
            ResetEnemy(obj);
        }
    }

    private void ResetEnemy(GameObject enemy)
    {
        
    }

    private GameObject InstantiateNewEnemy()
    {
        return Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
    }
}
