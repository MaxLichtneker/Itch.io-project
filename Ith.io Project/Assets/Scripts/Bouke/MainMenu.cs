using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;
    public GameObject controls;

    public void Start()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        controls.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void Controls()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void BackToMainMenu()
    {
        controls.SetActive(false);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
