using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFXPool : MonoBehaviour
{
    [SerializeField] GameObject playerHitPFX;
    [SerializeField] GameObject enemyHitPFX;

    [SerializeField] int playerMaxPoolCount = 8;
    [SerializeField] int enemyMaxPoolCount = 20;

    private GameObject[] playerPool;
    private GameObject[] enemyPool;

    int playerNextUp = 0;
    int enemyNextUp = 0;

    private void Start()
    {
        playerPool = new GameObject[playerMaxPoolCount];
        enemyPool = new GameObject[enemyMaxPoolCount];
    }

    public void SpawnNextInPlayerPool(Vector3 position)
    {
        if (playerPool[playerNextUp] != null)
        {
            Respawn(playerPool[playerNextUp], position);
        }
        else
        {
            playerPool[playerNextUp] = Instantiate(playerHitPFX, transform.position, Quaternion.identity, transform);
            playerPool[playerNextUp].GetComponent<ParticleSystem>().Play();
        }
    }

    public void SpawnNextInEnemyPool(Vector3 position)
    {
        if (enemyPool[enemyNextUp] != null)
        {
            Respawn(enemyPool[enemyNextUp], position);
        }
        else
        {
            enemyPool[enemyNextUp] = Instantiate(enemyHitPFX, transform.position, Quaternion.identity, transform);
            enemyPool[enemyNextUp].GetComponent<ParticleSystem>().Play();
        }
    }

    private void Respawn(GameObject item, Vector3 position)
    {
        ParticleSystem ps = item.GetComponent<ParticleSystem>();
        ps.Stop();
        item.transform.position = position;        
        ps.Play();
    }
}
