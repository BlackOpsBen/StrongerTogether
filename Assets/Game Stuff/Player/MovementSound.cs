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
                AudioManager.Instance.PlayAudioClip2DLooping("run", gameObject.name);
            }
            else if (movement.GetIsActive())
            {
                StopRunSound();
            }
        }
    }

    private void StopRunSound()
    {
        AudioManager.Instance.StopLooping(gameObject.name);
    }
}
