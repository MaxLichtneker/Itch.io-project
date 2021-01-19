using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject name;
    public GameObject controls;
    public TMP_InputField inputText;
    public Button StartGameButton;


    public void Start()
    {
        mainMenu.SetActive(true);
        name.SetActive(false);
        controls.SetActive(false);
        inputText.characterLimit = 3;
        
    }

    private void Update()
    {
        inputText.text = inputText.text.ToUpper();
        if(inputText.text == null)
        {
            StartGameButton.interactable = false;
        }
        else
        {
            StartGameButton.interactable = true;
        }
        
    }
    public void StartGame()
    {
        SoundManger.instance.Play("Click");
        if(inputText.text == "")
        {
            HoldLeaderBordInfo.instance.name = "GAY";
            Debug.Log("ja");
        }
        else
        {
            HoldLeaderBordInfo.instance.name = inputText.text; ControlsMenu
        }
        
        SceneManager.LoadScene(1);

    }
    public void GoToNameCreation()
    {
        SoundManger.instance.Play("Click");
        //SceneManager.LoadScene(1);
        name.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LeaderBord()
    {
        SoundManger.instance.Play("Click");
        SceneManager.LoadScene(2);
    }
    public void Controls()
    {
        SoundManger.instance.Play("Click");
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void BackToMainMenu()
    {
        SoundManger.instance.Play("Click");
        controls.SetActive(false);
        name.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void OnApplicationQuit()
    {
        SoundManger.instance.Play("Click");
    }
}
