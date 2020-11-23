using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantData plantData;

    [Range(0, 10)]
    [Header("how long it takes for the plant to grow")]
    [SerializeField] private float growthDuration = 0.0f;

    [Header("keeps track if the plant is fully grown or not")]
    [SerializeField] private bool fullyGrown = false;

    private SpriteRenderer plantSprite;

    private float startDuration = 0.0f;
    private int arrayIndex = 0;

    private void Start()
    {
        plantSprite = GetComponentInChildren<SpriteRenderer>();

        plantSprite.sprite = plantData.growthSprites[0];

        startDuration = growthDuration;
    }

    void Update()
    {
        TimerDecrease();

        if(plantData.growthSprites != null)
        {
            GrowPlant();
        }
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
            plantSprite.sprite = null;

            arrayIndex++;

            plantSprite.sprite = plantData.growthSprites[arrayIndex];
        }
        else if(arrayIndex == plantData.growthSprites.Length - 1)
        {
            fullyGrown = true;
        }
    }
}
