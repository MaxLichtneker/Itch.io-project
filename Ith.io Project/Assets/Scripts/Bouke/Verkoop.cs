using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verkoop : MonoBehaviour
{

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

    public void SellCarrot()
    {
        if(gm.amountCarrot > 0)
        {
            gm.amountCarrot -= 1;
            gm.AddMoney(gm.sellPriceCarrot);
        }
    }
    public void SellTomato()
    {
        if(gm.amountTomato > 0)
        {
            gm.amountTomato -= 1;
            gm.AddMoney(gm.sellPriceTomato);
            
        }
    }
    public void SellCapace()
    {
        if(gm.amountCapace > 0)
        {
            gm.amountCapace -= 1;
            gm.AddMoney(gm.sellPriceCapace);
        }
    }
    private void OnMouseDown()
    {
        gm.ActivateSellUi();
    }


}
