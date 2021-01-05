using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plot : MonoBehaviour
{
    [Header("Keeps track of what the state of the planted seed is")]
    public CropState cropState;

    [Header("the name of the plant that is currently planted")]
    [SerializeField] private string currentPlant = "";

    [Header("keeps track of the plot")]
    public bool plotTaken = false;

    [Header("GameObject of the seed Selection menu")]
    public GameObject SeedSelectionMenu = null;

    [Header("text that will appear when hovering above plot")]
    [SerializeField] private TextMeshPro plotText = null;

    private Plant plant;

    private GameManger gm;

    private void Awake()
    {
        gm = GameManger.FindObjectOfType<GameManger>();
    }
    
    private void Update()
    {
        if (plotTaken)
        {
            cropState = GetComponentInChildren<Plant>().cropState;
            plant = GetComponentInChildren<Plant>();

            currentPlant = plant.plantData.plantName;
        }
        else if (!plotTaken)
        {
            cropState = CropState.empty;
        }
    }

    //shows text when the mouse is over the plot
    private void OnMouseOver()
    {
        if(plotTaken == false)
        {
            plotText.text = "Plant seed";
        }
        else if (plotTaken)
        {
            plotText.text = "plot taken";
        }
    }

    //sets empties the string so when the mouse is not over plot text is not showing
    private void OnMouseExit()
    {
        plotText.text = "";
    }

    //when the player clicks on the plot it will open a menu to select a seed to plant
    private void OnMouseDown()
    {
        if (plotTaken == false)
        {
            SeedSelectionMenu.SetActive(true);
        }
        if(plotTaken == true && cropState == CropState.harvestable)
        {
            //than you can make here a option like if(andere enum == plantsoort.tomaat) of welke plant het ook is
            if(currentPlant == "Carrots")
            {
                gm.AddCarrot();
                SoundManger.instance.Play("Harvest");
            }

            if(currentPlant == "Cabbage")
            {
                gm.AddCapace();
                SoundManger.instance.Play("Harvest");
            }

            if(currentPlant == "Tomtato")
            {
                gm.AddTomato();
                SoundManger.instance.Play("Harvest");
            }

            var removeComponent = GetComponentInChildren<Plant>();
            removeComponent.RemovePlant();

            plotTaken = false;
        }
    }
    
    private void CheckPlantState()
    {
        if(cropState == CropState.dead)
        {
            plotTaken = false;
        }
    }
}
