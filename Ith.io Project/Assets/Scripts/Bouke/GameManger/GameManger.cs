using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManger : MonoBehaviour
{
    public int money;

    //how mutch I have of this plant
    public int amountCarrot;
    public int amountTomato;
    public int amountCapace;

    [HideInInspector] public bool sellUiActive;
    [HideInInspector] public bool buyUiActive;
    [HideInInspector] public bool ableToWalk;

    public TMP_Text money_text;

    public static bool gameEnd;
    private void Update()
    {
        //if a ui is active the player is not allowed to walk anymore
        if (sellUiActive || buyUiActive)
        {
            ableToWalk = false;
        }
        else
        {
            ableToWalk = true;
        }
        money_text.text = "Money: " + money.ToString();
        
        if(gameEnd == true)
        {
            HoldLeaderBordInfo.instance.money = money;
            LeaderBord.gameEnd = true;
            gameEnd = false;
        }
    }
    /// <summary>
    /// Call this function whe the amount of money you want to give.
    /// </summary>
    /// <param name="amount"></param>
    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void AddCarrot()
    {
        amountCarrot++;
    }
    public void AddTomato()
    {
        amountTomato++;
    }
    public void AddCapace()
    {
        amountCapace++;
    }

    
}
