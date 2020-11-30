using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    [Header("all the seeds and the amounts the player has")]
    public int carrotSeed, cabbageSeed, tomatoSeed;

    public static PlotManager plotManagerInstance;

    private void Awake()
    {
        plotManagerInstance = this;
    }
}
