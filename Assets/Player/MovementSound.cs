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
            AudioManager.Instance.StopSFXLoop(runSound);
        }
        else
        {
            if (movement.GetIsMoving())
            {
                AudioManager.Instance.PlaySFXLoop(runSound);
            }
            else if (movement.GetIsActive())
            {
                AudioManager.Instance.StopSFXLoop(runSound);
            }
        }
    }
}
