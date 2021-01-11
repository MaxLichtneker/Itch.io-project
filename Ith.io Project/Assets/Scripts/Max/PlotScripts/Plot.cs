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

    [Header("checks if the player has selected a plot")]
    private bool plotSelected = false;

    [Header("GameObject of the seed Selection menu")]
    public GameObject SeedSelectionMenu = null;

    [Header("transform of the player")]
    [SerializeField] private Transform playerTransform;

    [Header("text that will appear when hovering above plot")]
    [SerializeField] private TextMeshPro plotText = null;

    private Plant plant;
    private Movement movement;

    private GameManger gm;

    private void Awake()
    {
        movement = FindObjectOfType<Movement>();
        gm = GameManger.FindObjectOfType<GameManger>();
    }
    
    private void Update()
    {
        //checks if the player has selected a plot and if so then opens the seed selection menu
        if (!plotTaken && plotSelected)
        {
            if (playerTransform.position == movement.targetPos)
            {
                SeedSelectionMenu.SetActive(true);
            }
        }

        //when the plot is taken the variables will be changed to the aspects of the seed that has been planted
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
            plotSelected = true;
        }

        if (plotTaken == true && cropState == CropState.harvestable)
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
    
    //checks if the plant is dead and if so wil set the plot taken bool back to false
    private void CheckPlantState()
    {
        if(cropState == CropState.dead)
        {
            plotTaken = false;
        }
    }

    //when the player walks away from the plot the plot will not be selected anymore
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            plotSelected = false;
        }
    }
}
