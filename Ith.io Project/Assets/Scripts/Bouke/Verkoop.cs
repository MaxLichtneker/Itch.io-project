using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Verkoop : MonoBehaviour
{

    private GameManger gm;

    //hoow mutch the selling price is
    public int sellPriceCarrot;
    public int sellPriceTomato;
    public int sellPriceCapace;

    public TMP_Text t_amountCarrot;
    public TMP_Text t_amountTomato;
    public TMP_Text t_amountCapace;

    public GameObject sellui;

    private void Awake()
    {
        //get the gamemanger
        gm = GameManger.FindObjectOfType<GameManger>();
        if(gm == null)
        {
            Debug.LogError("Cant find the gamemanger in this scene!");
        }

        sellui.SetActive(gm.sellUiActive);
    }
    private void Update()
    {
        t_amountCarrot.text = "Carrots In Stock: " + gm.amountCarrot.ToString();
        t_amountTomato.text = "Tomatos In Stock: " + gm.amountTomato.ToString();
        t_amountCapace.text = "Capaces In Stock: " + gm.amountCapace.ToString();

        sellui.SetActive(gm.sellUiActive);
    }

    public void SellCarrot()
    {
        if(gm.amountCarrot > 0)
        {
            gm.amountCarrot -= 1;
            gm.AddMoney(sellPriceCarrot);
        }
    }
    public void SellTomato()
    {
        if(gm.amountTomato > 0)
        {
            gm.amountTomato -= 1;
            gm.AddMoney(sellPriceTomato);
            
        }
    }
    public void SellCapace()
    {
        if(gm.amountCapace > 0)
        {
            gm.amountCapace -= 1;
            gm.AddMoney(sellPriceCapace);
        }
    }
    private void OnMouseDown()
    {
        ActivateSellUi();
    }
    public void ActivateSellUi()
    {
        gm.sellUiActive = true;
    }


}
