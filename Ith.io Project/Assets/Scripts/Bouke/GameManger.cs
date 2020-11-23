using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManger : MonoBehaviour
{
    public int money;

    //hoow mutch the selling price is
    public int sellPriceCarrot;
    public int sellPriceTomato;
    public int sellPriceCapace;

    //how mutch I have of this plant
    public int amountCarrot;
    public int amountTomato;
    public int amountCapace;

    public TMP_Text t_amountCarrot;
    public TMP_Text t_amountTomato;
    public TMP_Text t_amountCapace;

    public GameObject sellui;
    public bool selluiactive;

    public bool ableToWalk;

    private void Awake()
    {
        sellui.SetActive(selluiactive);
    }

    private void Update()
    {
        t_amountCarrot.text = "Carrots In Stock: " + amountCarrot.ToString();
        t_amountTomato.text = "Tomatos In Stock: " + amountTomato.ToString();
        t_amountCapace.text = "Capaces In Stock: " + amountCapace.ToString();

        sellui.SetActive(selluiactive);

        ableToWalk = !selluiactive;
    }
    public void AddMoney(int amount)
    {
        money += amount;
    }
    public void ActivateSellUi()
    {
        selluiactive = true;
    }
}
