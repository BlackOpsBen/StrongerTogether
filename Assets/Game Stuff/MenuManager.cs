using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject instructionsMenu;
    [SerializeField] GameObject creditsMenu;

    private void Start()
    {
        if (instructionsMenu != null)
        {
            instructionsMenu.SetActive(false);
        }
        if (creditsMenu != null)
        {
            creditsMenu.SetActive(false);
        }
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
        if (instructionsMenu != null)
        {
            instructionsMenu.SetActive(value);
        }
        if (mainMenu != null)
        {
            mainMenu.SetActive(!value);
        }
    }

    public void ShowCredits(bool value)
    {
        if (creditsMenu != null)
        {
            creditsMenu.SetActive(value);
        }
        if (mainMenu != null)
        {
            mainMenu.SetActive(!value);
        }
    }


}
