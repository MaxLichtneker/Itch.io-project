﻿using System.Collections;
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

    

    public  bool clickedon;

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
        //show homw mutch of everything is still in stock
        t_amountCarrot.text = "Carrots In Stock: " + gm.amountCarrot.ToString();
        t_amountTomato.text = "Tomatos In Stock: " + gm.amountTomato.ToString();
        t_amountCapace.text = "cabbage In Stock: " + gm.amountCapace.ToString();

        sellui.SetActive(gm.sellUiActive);

        
    }
    /// <summary>
    /// sell a carrot
    /// used for the sell carrot button in the sell ui
    /// </summary>
    public void SellCarrot()
    {
        if(gm.amountCarrot > 0)
        {
            SoundManger.instance.Play("Click");
            gm.amountCarrot -= 1;
            gm.AddMoney(sellPriceCarrot);
        }
    }
    /// <summary>
    /// sell a tomato
    /// used for the sell tomato button in the sell ui
    /// </summary>
    public void SellTomato()
    {
        if(gm.amountTomato > 0)
        {
            SoundManger.instance.Play("Click");
            gm.amountTomato -= 1;
            gm.AddMoney(sellPriceTomato);
            
        }
    }
    /// <summary>
    /// sell a capace
    /// used for the sell capace button in the sell ui
    /// </summary>
    public void SellCapace()
    {
        if(gm.amountCapace > 0)
        {
            SoundManger.instance.Play("Click");
            gm.amountCapace -= 1;
            gm.AddMoney(sellPriceCapace);
        }
    }
    private void OnMouseDown()
    {
        clickedon = true;
    }
    public void ActivateSellUi()
    {
        gm.sellUiActive = true;
    }
    /// <summary>
    /// the exit shop
    /// this is used for the exit shop button in the sell ui
    /// </summary>
    public void ExitShop()
    {
        SoundManger.instance.Play("Click");
        clickedon = false;
        gm.sellUiActive = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
                ActivateSellUi();
        }
    }


}
