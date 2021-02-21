using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] int maxItems = 100;
    private GameObject[] poolItems;
    private int currentItem = 0;
    [SerializeField] bool randomOffsetAndRotation;

    private void Start()
    {
        poolItems = new GameObject[maxItems];
    }

    public GameObject SpawnNextItem(Vector3 position)
    {
        GameObject itemToReturn;
        if (poolItems[currentItem] != null)
        {
            poolItems[currentItem].transform.position = GetPosition(position);
            poolItems[currentItem].transform.rotation = GetRotation();
        }
        else
        {
            poolItems[currentItem] = Instantiate(item, GetPosition(position), GetRotation(), transform);
        }
        itemToReturn = poolItems[currentItem];

        currentItem++;
        currentItem = currentItem % maxItems;

        return itemToReturn;

    }

    private Vector3 GetPosition(Vector3 position)
    {
        if (randomOffsetAndRotation)
        {
            float randX = UnityEngine.Random.Range(-0.5f, .5f);
            float randY = UnityEngine.Random.Range(-0.5f, .5f);
            return new Vector3(position.x + randX, position.y + randY, position.z);
        }
        else
        {
            return position;
        }
    }

    private Quaternion GetRotation()
    {
        if (randomOffsetAndRotation)
        {
            float randZRot = UnityEngine.Random.Range(0f, 360f);
            Vector3 newRot = new Vector3(0f, 0f, randZRot);
            return Quaternion.Euler(newRot);
        }
        else
        {
            return Quaternion.identity;
        }
    }
}
