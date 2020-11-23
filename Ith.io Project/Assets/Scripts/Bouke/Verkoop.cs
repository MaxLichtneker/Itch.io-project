using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verkoop : MonoBehaviour
{
    public int price_Carrot;
    public int price_Tomato;
    public int price_Capace;

    private GameManger gm;

    private void Awake()
    {
        //get the gamemanger
        gm = GameManger.FindObjectOfType<GameManger>();
        if(gm == null)
        {
            Debug.LogError("Cant find the gamemanger in this scene!");
        }
    }

    private void Update()
    {
        
    }

    

    public void VerkoopCarrot()
    {
        if(gm.amountCarrot > 0)
        {
            gm.amountCarrot -= 1;
            gm.AddMoney(gm.sellPriceCarrot);
        }
    }
    public void Verkooptomato()
    {
        if(gm.amountTomato > 0)
        {
            gm.amountTomato -= 1;
            gm.AddMoney(gm.sellPriceTomato);
            
        }
    }
    public void Verkoopcapace()
    {

    }


}
