using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class Torch : MonoBehaviour
{
    [Header("checks if the torch is equipped or not")]
    public bool isEquiped = false;

    [Range(0.0f, 20.0f)]
    [Header("Amount of time the player has before the torch burns out")]
    public float timer = 0.0f;

    [HideInInspector]
    public float maxTimerValue;

    [Header("image that shows how much longer the torch will stay lit")]
    [SerializeField] private Image sliderImage = null;

    [Header("Lightsource of the torch")]
    [SerializeField] private Light2D torchLight;

    [Header("GameObject with sprite visual")]
    [SerializeField] private GameObject spriteVisual = null;

    private void Start()
    {
        sliderImage.enabled = false;

        maxTimerValue = timer;
    }

    void Update()
    {
        TorchBurnOut();

        KeepTrackOfTimer();

        if(Input.GetKeyDown(KeyCode.Alpha1) && isEquiped == false)
        {
            EquipTorch();

            sliderImage.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && isEquiped)
        {
            UnequipTorch();
            sliderImage.enabled = false;
        }
    }

    //equips the torch
    private void EquipTorch()
    {
        isEquiped = true;

        spriteVisual.SetActive(true);
    }
    
    //unequips the torch
    private void UnequipTorch()
    {
        isEquiped = false;

        spriteVisual.SetActive(false);

    }

    //counts down to 0 and then makes the torch useless against enemies
    private void TorchBurnOut()
    {
        timer = Mathf.Clamp(timer, 0.0f, maxTimerValue);

        if (isEquiped)
        {
            sliderImage.fillAmount = timer / maxTimerValue;
            timer -= 1.0f * Time.deltaTime;
        }
    }

    private void KeepTrackOfTimer()
    {
        if(timer <= 0.0f)
        {
            torchLight.intensity = 0.0f;
        }
        else
        {
            torchLight.intensity = 1.5f;
        }
    }

}
