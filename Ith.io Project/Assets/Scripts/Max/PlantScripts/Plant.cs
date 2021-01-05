using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CropState
{
    empty,
    seed,
    harvestable,
    dead,
    monster
}

public class Plant : MonoBehaviour
{
    public PlantData plantData;

    [HideInInspector]
    public CropState cropState;

    [Range(0, 10)]
    [Header("how long it takes for the plant to grow")]
    [SerializeField] private float growthDuration = 0.0f;

    [Range(0, 20)]
    [Header("how long it will take for the monster to spawn after the plant dies")]
    [SerializeField] private float monsterSpawnTimer = 0.0f;

    [Header("keeps track if the plant is fully grown or not")]
    [SerializeField] private bool fullyGrown = false;

    private bool monsterSpawned = false;

    [Header("Prefab of the plant monster that spawns once the plant dies")]
    [SerializeField] private GameObject monster = null;

    private SpriteRenderer plantSprite = null;

    private float startDuration = 0.0f;
    private int arrayIndex = 0;

    private void Start()
    {
        plantSprite = GetComponentInChildren<SpriteRenderer>();

        cropState = CropState.seed;

        plantSprite.sprite = plantData.growthSprites[0];

        startDuration = growthDuration;
    }

    void Update()
    {
        TimerDecrease();

        if(plantData.growthSprites != null)
        {
            GrowPlant();
            
            if(arrayIndex == plantData.growthSprites.Length - 2)
            {
                cropState = CropState.harvestable;
            }
        }

        if (!monsterSpawned)
        {
            SpawnMonster();
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
            cropState = CropState.dead;
            fullyGrown = true;
        }
    }

    //spawns a monster after a certain amount of time after the plant has died
    private void SpawnMonster()
    {
        if (fullyGrown)
        {
            monsterSpawnTimer -= 1.0f * Time.deltaTime;

            monsterSpawnTimer = Mathf.Clamp(monsterSpawnTimer, 0, 20);

            if(monsterSpawnTimer <= 0)
            {
                cropState = CropState.monster;

                Instantiate(monster, gameObject.transform.position, Quaternion.identity);

                monsterSpawned = true;

                monsterSpawnTimer = 5.0f;
            }

        }
    }

    public void RemovePlant()
    {
        Destroy(gameObject);
    }

}
