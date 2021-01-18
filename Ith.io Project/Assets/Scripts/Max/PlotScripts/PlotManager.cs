using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    [Header("all the seeds and the amounts the player has")]
    public int carrotSeed, cabbageSeed, tomatoSeed;

    [SerializeField]private bool animationPlay = false;

    [Header("All the available plots")]
    [SerializeField] private GameObject[] plots;

    [SerializeField] private List<CropState> cropStates = new List<CropState>();

    [Header("Panel that activates when all the plants overgrow")]
    [SerializeField] private GameObject lossPanel;

    [SerializeField] private Animator playerAnimator = null;

    CropState cropState;

    public static PlotManager plotManagerInstance;

    private void Awake()
    {
        plotManagerInstance = this;
    }

    private void Update()
    {
        SetBoolToTrue();

        SetAnimatorValues();

        for (int i = 0; i < plots.Length; i++)
        {
            cropStates[i] = plots[i].GetComponent<Plot>().cropState;
            animationPlay = plots[i].GetComponent<Plot>().interactibleAnimation;
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
                GameManger.gameEnd = true;
            }
        }
    }

    private void SetAnimatorValues()
    {
        if(playerAnimator != null)
        {
            playerAnimator.SetBool("Grab", animationPlay);
        }
    }

    public static bool IsMonster(CropState states)
    {
        return CropState.dead == states;
    }

    private void SetBoolToTrue()
    {
        for (int i = 0; i < plots.Length; i++)
        {
            if (plots[i].GetComponent<Plot>().interactibleAnimation == true)
            {
                animationPlay = true;
            }
        }
    
    }
}
