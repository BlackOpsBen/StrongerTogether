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
        if (GameManager.Instance.GetIsPaused())
        {
            StopRunSound();
        }
        else
        {
            if (movement.GetIsMoving())
            {
                // TODO start run sound loop
            }
            else if (movement.GetIsActive())
            {
                StopRunSound();
            }
        }
    }

    private void StopRunSound()
    {
        // TODO stop run sound loop
    }
}
