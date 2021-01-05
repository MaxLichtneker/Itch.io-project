using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSelection : MonoBehaviour
{
    public enum SelectedSeed
    {
        carrot,
        cabbage,
        tomato
    }

    [Header("Select Which seed is in this slot")]
    public SelectedSeed selectedSeed = SelectedSeed.carrot;

    [Header("Prefabs of all the seeds")]
    public GameObject carrotPrefab = null, cabagePrefab = null, tomatoPrefab = null;

    [Header("UI component attached to the plot")]
    [SerializeField]private GameObject uiVisual = null;

    [Header("overlay for if the player has no seeds anymore")]
    [SerializeField] private GameObject noSeedsVisualCarrots = null;
    [SerializeField] private GameObject noSeedsVisualCabbage = null;
    [SerializeField] private GameObject noSeedsVisualTomato = null;

    [Header("transform of the plot this selection is attached to")]
    [SerializeField]private Transform plotTransform = null;

    private Plot plot;

    void Start()
    {
        plot = GetComponentInParent<Plot>();
    }

    private void Update()
    {
        CheckIfSeedNull();
    }

    private void OnMouseDown()
    {
        SelectSeed();
    }

    private void SelectSeed()
    {
        switch (selectedSeed)
        {
            case SelectedSeed.carrot:
                if(PlotManager.plotManagerInstance.carrotSeed > 0)
                {
                    PlotManager.plotManagerInstance.carrotSeed--;

                    uiVisual.SetActive(false);
                    plot.plotTaken = true;

                    var child = Instantiate(carrotPrefab, plotTransform.position, Quaternion.identity);
                    child.transform.parent = plotTransform;
                    SoundManger.instance.Play("Seeding");
                }
                break;
            case SelectedSeed.cabbage:

                if(PlotManager.plotManagerInstance.cabbageSeed > 0)
                {
                    PlotManager.plotManagerInstance.cabbageSeed--;

                    uiVisual.SetActive(false);
                    plot.plotTaken = true;

                    var child2 = Instantiate(cabagePrefab, plotTransform.position, Quaternion.identity);
                    child2.transform.parent = plotTransform;
                    SoundManger.instance.Play("Seeding");
                }
                break;
            case SelectedSeed.tomato:

                if(PlotManager.plotManagerInstance.tomatoSeed > 0)
                {
                    PlotManager.plotManagerInstance.tomatoSeed--;

                    uiVisual.SetActive(false);
                    plot.plotTaken = true;

                    var child3 = Instantiate(tomatoPrefab, plotTransform.position, Quaternion.identity);
                    child3.transform.parent = plotTransform;
                    SoundManger.instance.Play("Seeding");
                }
                break;
        }
    }

    //checks if the player has no seeds anymore and if so turns on a UI overlay
    private void CheckIfSeedNull()
    {
        if (PlotManager.plotManagerInstance.carrotSeed == 0)
        {
            noSeedsVisualCarrots.SetActive(true);
        }
        else
        {
            noSeedsVisualCarrots.SetActive(false);
        }

        if (PlotManager.plotManagerInstance.cabbageSeed == 0)
        {
            noSeedsVisualCabbage.SetActive(true);
        }
        else
        {
            noSeedsVisualCabbage.SetActive(false);
        }

        if (PlotManager.plotManagerInstance.tomatoSeed == 0)
        {
            noSeedsVisualTomato.SetActive(true);
        }
        else
        {
            noSeedsVisualTomato.SetActive(false);
        }

    }
}
