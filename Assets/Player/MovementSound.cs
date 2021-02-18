using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    private Movement movement;
    [SerializeField] string runSound;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (movement.GetIsMoving())
        {
            Debug.Log("Is Moving");
            AudioManager.Instance.PlaySFXLoop(runSound);
        }
        else if (movement.GetIsActive())
        {
            Debug.Log("Stopped Moving");
            AudioManager.Instance.StopSFXLoop(runSound);
        }
    }
}
