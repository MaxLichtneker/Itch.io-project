using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("panel attached to the canvas")]
    [SerializeField] private GameObject pausePanel = null;

    [SerializeField] private bool paused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;

            paused = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;

            paused = false;
        }
    }

    public void Resume()
    {
        SoundManger.instance.Play("Click");
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;

        paused = false;
    }

    public void BackToMainMenu()
    {
        SoundManger.instance.Play("Click");
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        SoundManger.instance.Play("Click");
        Application.Quit();
    }
}
