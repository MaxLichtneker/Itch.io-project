using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLeaderBordScore : MonoBehaviour
{
    public static bool gameEnd;
    private void Start()
    {
        if (gameEnd == true)
        {
            LeaderBord.instance.AddLeaderBordEntry(HoldLeaderBordInfo.instance.money, HoldLeaderBordInfo.instance.name);
            gameEnd = false;
        }
    }
}
