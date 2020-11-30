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

    public List<Plot> plots;

    private void Awake()
    {
        foreach(GameObject plot in GameObject.FindGameObjectsWithTag("Plots"))
        {
            plots.Add(plot.GetComponent<Plot>());
        }
    }

    private void Update()
    {
        ableToWalk = !sellUiActive;
    }
    /// <summary>
    /// Call this function whe the amount of money you want to give.
    /// </summary>
    /// <param name="amount"></param>
    public void AddMoney(int amount)
    {
        money += amount;
    }

    
}
