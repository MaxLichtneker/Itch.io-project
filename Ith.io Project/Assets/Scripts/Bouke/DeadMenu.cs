using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public void ToLeaderbord()
    {
        SoundManger.instance.Play("Click");
        SceneManager.LoadScene(2);
    }
    
}
