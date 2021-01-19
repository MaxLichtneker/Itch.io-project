using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SoundManger.instance.Play("Click");
        SceneManager.LoadScene(0);
        
    }
}
