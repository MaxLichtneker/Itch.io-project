using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantData", menuName = "ScriptableObjects/PlantInformation", order = 1)]
public class PlantData : ScriptableObject
{
    [Header("name of the plant")]
    public string plantName;

    [Header("the speed at which the plant will grow")]
    public float growthSpeed;

    [Header("sprites for every growth stage of the plant from 0 to 1")]
    public GameObject[] growthSprites;
}
