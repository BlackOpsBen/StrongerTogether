using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Transform baseParent;
    [SerializeField] float amplitude;
    [SerializeField] float limitSmoothing;
    [SerializeField] float cooldownSpeed = 1f;
    [SerializeField] float amount = 0;
    [SerializeField] float amountLimit;
    private float zOffset = -1f;

    private void Update()
    {
        amount = Mathf.Clamp(amount, 0f, amountLimit);

        if (amount > 0f)
        {
            amount -= Time.deltaTime * cooldownSpeed;
        }

        Vector3 offsetBasePos = new Vector3(baseParent.transform.position.x, baseParent.transform.position.y, zOffset);

        int randX = UnityEngine.Random.Range(-1, 1);
        int randY = UnityEngine.Random.Range(-1, 1);
        int randZ = UnityEngine.Random.Range(-1, 1);
        Vector3 amplifiedRand = new Vector3(randX * amplitude, randY * amplitude, randZ * amplitude);

        Vector3 offsetRandPos = new Vector3(offsetBasePos.x + amplifiedRand.x, offsetBasePos.y + amplifiedRand.y, offsetBasePos.z + amplifiedRand.z);

        //transform.position = offsetRandPos; ;
        transform.position = Vector3.Lerp(transform.position, offsetRandPos, amount);
    }

    public void AddShake(float amount)
    {
        this.amount += amount;
    }
}
