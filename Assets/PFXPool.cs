using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFXPool : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] int maxPoolCount = 20;

    private GameObject[] pool;

    int nextUp = 0;

    private void Start()
    {
        pool = new GameObject[maxPoolCount];
    }

    public void SpawnNextInPool(Vector3 position)
    {
        if (pool[nextUp] != null)
        {
            Respawn(pool[nextUp], position);
        }
        else
        {
            pool[nextUp] = Instantiate(prefab, transform.position, Quaternion.identity, transform);
            pool[nextUp].GetComponent<ParticleSystem>().Play();
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
