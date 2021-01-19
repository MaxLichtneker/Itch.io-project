using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    public List<GameObject> Pages;

    private int Whatpage;
    private void Start()
    {
        for (int i = 0; i < Pages.Count ; i++)
        {
            Pages[i].SetActive(false);
        }
        Pages[Whatpage].SetActive(true);
    }
    public void NextPage()
    {
        if(Whatpage == Pages.Count -1)
        {
            return;
        }
        SoundManger.instance.Play("Click");
        Whatpage++;
        Pages[Whatpage - 1].SetActive(false);
        Pages[Whatpage].SetActive(true);
    }

    public void PriviousPage()
    {
        if(Whatpage == 0)
        {
            return;
        }
        SoundManger.instance.Play("Click");
        Whatpage--;
        Pages[Whatpage + 1].SetActive(false);
        Pages[Whatpage].SetActive(true);
    }
    
}
