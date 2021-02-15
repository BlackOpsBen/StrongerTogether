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
        controls.DefaultActionMap.SelectPrev.performed += ctx => SelectPrevious();
        controls.DefaultActionMap.Select0.performed += ctx => Select(0);
        controls.DefaultActionMap.Select1.performed += ctx => Select(1);
        controls.DefaultActionMap.Select2.performed += ctx => Select(2);
        controls.DefaultActionMap.Select3.performed += ctx => Select(3);
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
    }

    void SelectPrevious()
    {
        playerCharacters[currentPlayer].SetIsActive(false);
        if (currentPlayer == 0)
        {
            currentPlayer = playerCharacters.Length;
        }
        else
        {
            currentPlayer--;
        }
        playerCharacters[currentPlayer].SetIsActive(true);
    }

    void Select(int index)
    {
        if (index < playerCharacters.Length)
        {
            playerCharacters[currentPlayer].SetIsActive(false);
            currentPlayer = index;
            playerCharacters[currentPlayer].SetIsActive(true);
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
