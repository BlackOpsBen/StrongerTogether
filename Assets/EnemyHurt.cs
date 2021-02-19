using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour, IHurt
{
    [SerializeField] GameObject hitPFX;
    private Transform parent;

    private int maxHitPFX = 2;

    private GameObject[] hitPFXPool;

    private int currentIndex = 0;

    private void Start()
    {
        hitPFXPool = new GameObject[maxHitPFX];
        parent = GameObject.FindGameObjectWithTag("HitPFXParent").transform;
    }

    public void TriggerHurtBehavior()
    {
        if (hitPFXPool[currentIndex] != null)
        {
            ParticleSystem ps = hitPFXPool[currentIndex].GetComponent<ParticleSystem>();
            ps.Stop();
            hitPFXPool[currentIndex].transform.position = transform.position;
            ps.Play();
        }
        else
        {
            hitPFXPool[currentIndex] = Instantiate(hitPFX, transform.position, Quaternion.identity, parent);
            ParticleSystem ps = hitPFXPool[currentIndex].GetComponent<ParticleSystem>();
            ps.Play();
        }
        currentIndex++;
        currentIndex = currentIndex % maxHitPFX;
    }
}
