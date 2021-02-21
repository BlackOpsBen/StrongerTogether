using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject instructionsMenu;

    private void Start()
    {
        instructionsMenu.SetActive(false);
        if (mainMenu != null)
        {
            mainMenu.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowInstructions(bool value)
    {
        instructionsMenu.SetActive(value);
        if (mainMenu != null)
        {
            mainMenu.SetActive(!value);
        }
    }


}
