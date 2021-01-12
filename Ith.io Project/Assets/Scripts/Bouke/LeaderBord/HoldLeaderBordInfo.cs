using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLeaderBordInfo : MonoBehaviour
{
    public static HoldLeaderBordInfo instance;

    public string name = "AAA";
    public int money = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
}
