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
    [HideInInspector] public bool ableToWalk;

    private void Awake()
    {
        
    }

    private void Update()
    {
        ableToWalk = !sellUiActive;
    }
    /// <summary>
    /// here the money is counted up
    /// </summary>
    /// <param name="amount"></param>
    public void AddMoney(int amount)
    {
        money += amount;
    }
    
}
