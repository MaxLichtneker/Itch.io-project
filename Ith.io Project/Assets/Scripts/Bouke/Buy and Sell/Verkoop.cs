using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
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

=======

public class Verkoop : MonoBehaviour
{
    public int price_Carrot;
    public int price_Tomato;
    public int price_Capace;

    private GameManger gm;

>>>>>>> Stashed changes
    private void Awake()
    {
        //get the gamemanger
        gm = GameManger.FindObjectOfType<GameManger>();
        if(gm == null)
        {
            Debug.LogError("Cant find the gamemanger in this scene!");
        }
<<<<<<< Updated upstream

        
        sellui.SetActive(gm.sellUiActive);
    }
    private void Update()
    {
        //show homw mutch of everything is still in stock
        t_amountCarrot.text = "Carrots In Stock: " + gm.amountCarrot.ToString();
        t_amountTomato.text = "Tomatos In Stock: " + gm.amountTomato.ToString();
        t_amountCapace.text = "Capaces In Stock: " + gm.amountCapace.ToString();

        sellui.SetActive(gm.sellUiActive);

        
    }
    /// <summary>
    /// sell a carrot
    /// used for the sell carrot button in the sell ui
    /// </summary>
    public void SellCarrot()
=======
    }

    private void Update()
    {
        
    }

    

    public void VerkoopCarrot()
>>>>>>> Stashed changes
    {
        if(gm.amountCarrot > 0)
        {
            gm.amountCarrot -= 1;
<<<<<<< Updated upstream
            gm.AddMoney(sellPriceCarrot);
        }
    }
    /// <summary>
    /// sell a tomato
    /// used for the sell tomato button in the sell ui
    /// </summary>
    public void SellTomato()
=======
            gm.AddMoney(gm.sellPriceCarrot);
        }
    }
    public void Verkooptomato()
>>>>>>> Stashed changes
    {
        if(gm.amountTomato > 0)
        {
            gm.amountTomato -= 1;
<<<<<<< Updated upstream
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
        clickedon = false;
        gm.sellUiActive = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
                ActivateSellUi();
        }
=======
            gm.AddMoney(gm.sellPriceTomato);
            
        }
    }
    public void Verkoopcapace()
    {

>>>>>>> Stashed changes
    }


}
