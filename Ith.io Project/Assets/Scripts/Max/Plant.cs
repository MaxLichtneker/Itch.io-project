using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantData plantData;

    [Header("how long it takes for the plant to grow")]
    [SerializeField] private float growthDuration = 0.0f;

    [Header("keeps track if the plant is fully grown or not")]
    [SerializeField] private bool fullyGrown = false;

    [Header("sprites for every growth stage of the plant from 0 to 1")]
    public GameObject[] growthSprites = null;

    private float startDuration = 0.0f;
    private int arrayIndex = 0;

    private void Start()
    {
        startDuration = growthDuration;
    }

    void Update()
    {
        TimerDecrease();

        GrowPlant();
    }

    //decreases the timer for growth of one iteration
    private void TimerDecrease()
    {
        if(growthDuration > 0 && fullyGrown == false)
        {
            growthDuration -= plantData.growthSpeed * Time.deltaTime;
        }
        else if(growthDuration <= 0)
        {
            growthDuration = startDuration;
        }
    }

    //turns on the new sprite and turns the older one off
    private void GrowPlant()
    {
        if(growthDuration <= 0 && fullyGrown == false)
        {
            growthSprites[arrayIndex].SetActive(false);

            arrayIndex++;

            growthSprites[arrayIndex].SetActive(true);
        }
        else if(arrayIndex == growthSprites.Length - 1)
        {
            fullyGrown = true;
        }
    }
}
