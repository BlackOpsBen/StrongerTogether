using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isActive = false;

    PlayerControls controls;

    Vector2 movement;

    [SerializeField] Transform facing;

    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float rotationSpeed = 10f;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();

        controls = new PlayerControls();

        controls.DefaultActionMap.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.DefaultActionMap.Move.canceled += ctx => movement = Vector2.zero;
    }

    private void Update()
    {
        if (isActive && health.GetCurrentHealth() > 0)
        {
            MovePlayer();
            RotatePlayer();
        }
    }

    void MovePlayer()
    {
        Vector2 m = new Vector2(movement.x, movement.y) * Time.deltaTime * movementSpeed;
        transform.Translate(m, Space.World);
    }

    void RotatePlayer()
    {
        if (movement.magnitude > float.Epsilon)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            facing.rotation = Quaternion.Slerp(facing.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void SetIsActive(bool value)
    {
        isActive = value;
    }

    public bool GetIsMoving()
    {
        if (isActive && movement.magnitude > float.Epsilon)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnEnable()
    {
        controls.DefaultActionMap.Enable();
    }

    private void OnDisable()
    {
        controls.DefaultActionMap.Disable();
    }
}
