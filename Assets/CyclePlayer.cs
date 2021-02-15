using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclePlayer : MonoBehaviour
{
    Movement[] playerCharacters;

    PlayerControls controls;

    private int currentPlayer = 0;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.DefaultActionMap.SelectNext.performed += ctx => SelectNext();
    }

    void Start()
    {
        playerCharacters = FindObjectsOfType<Movement>();
        playerCharacters[currentPlayer].SetIsActive(true);
    }

    void SelectNext()
    {
        playerCharacters[currentPlayer].SetIsActive(false);
        currentPlayer++;
        currentPlayer = currentPlayer % playerCharacters.Length;
        playerCharacters[currentPlayer].SetIsActive(true);
        Debug.Log("Next player: " + currentPlayer.ToString());
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
