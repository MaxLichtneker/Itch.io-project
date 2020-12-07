using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public int money;

    //hoow mutch the selling price is
    public int sellPriceCarrot;
    public int sellPriceTomato;
    public int sellPriceCapace;

    //how mutch I have of this plant
    [HideInInspector] public int amountCarrot;
    [HideInInspector] public int amountTomato;
    [HideInInspector] public int amountCapace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMoney(int amount)
    {
        money += amount;
    }
}
