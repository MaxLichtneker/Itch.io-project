using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    [Header("all the seeds and the amounts the player has")]
    public int carrotSeed, cabbageSeed, tomatoSeed;

    [Header("All the available plots")]
    [SerializeField] private GameObject[] plots;

    [SerializeField] private List<CropState> cropStates = new List<CropState>();

    [Header("Panel that activates when all the plants overgrow")]
    [SerializeField] private GameObject lossPanel;

    CropState cropState;

    public static PlotManager plotManagerInstance;

    private void Awake()
    {
        plotManagerInstance = this;
    }

    private void Update()
    {
        for (int i = 0; i < plots.Length; i++)
        {
            cropStates[i] = plots[i].GetComponent<Plot>().cropState;
        }

        CheckAllPlots();
    }

    private void CheckAllPlots()
    {
        for (int i = 0; i < cropStates.Count; i++)
        {
            if (cropStates.TrueForAll(IsMonster))
            {
                Time.timeScale = 0.0f;

                lossPanel.SetActive(true);
            }
        }
    }

    public static bool IsMonster(CropState states)
    {

        return CropState.dead == states;
    }

}
