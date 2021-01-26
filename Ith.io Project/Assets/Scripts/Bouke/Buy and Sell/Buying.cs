using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buying : MonoBehaviour
{
    private GameManger gm;

    //the cost of buying seeds For the vetebals
    public int buyingPriceCarrotSeeds;
    public int buyingPriceTomatoSeeds;
    public int buyingPriceCapaceSeeds;

    public TMP_Text textCarrotSeedPrice;
    public TMP_Text textTomatoSeedPrice;
    public TMP_Text textCapaceSeedPrice;

    public GameObject buyUi;

    private void Awake()
    {
        gm = GameManger.FindObjectOfType<GameManger>();

        if(gm == null)
        {
            Debug.LogError("Cant Find the GameManger in this scene Make sure the game Manger is in this scene");
        }
    }
    private void Update()
    {
        textCarrotSeedPrice.text = "Carrot Seeds Price: " + buyingPriceCarrotSeeds.ToString();
        textTomatoSeedPrice.text = "Tomato Seeds Price: " + buyingPriceTomatoSeeds.ToString();
        textCapaceSeedPrice.text = "Capace Seeds Price: " + buyingPriceCapaceSeeds.ToString();


        buyUi.SetActive(gm.buyUiActive);
    }

    public void BuyCarrotSeeds()
    {
        if(gm.money >= buyingPriceCarrotSeeds)
        {
            SoundManger.instance.Play("Click");
            gm.money -= buyingPriceCarrotSeeds;
            PlotManager.plotManagerInstance.carrotSeed++;
        }
    }
    public void BuyTomatoSeeds()
    {
        if(gm.money >= buyingPriceTomatoSeeds)
        {
            SoundManger.instance.Play("Click");
            gm.money -= buyingPriceTomatoSeeds;
            PlotManager.plotManagerInstance.tomatoSeed++;
        }
    }
    /// <summary>
    /// buy the seeds for money 
    /// </summary>
    public void BuyCapaceSeeds()
    {
        if (gm.money >= buyingPriceCapaceSeeds)
        {
            SoundManger.instance.Play("Click");
            gm.money -= buyingPriceCapaceSeeds;
            PlotManager.plotManagerInstance.cabbageSeed++;
        }
    }


    /// <summary>
    /// activate the Buy UI
    /// </summary>
    public void ActivateBuyUI()
    {
        gm.buyUiActive = true;
    }

    /// <summary>
    /// exit the Buy UI
    /// </summary>
    public void ExitBuyUI()
    {
        SoundManger.instance.Play("Click");
        gm.buyUiActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateBuyUI();
        }
    }


}
