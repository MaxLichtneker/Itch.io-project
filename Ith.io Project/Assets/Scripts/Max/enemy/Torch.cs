using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [Header("checks if the torch is equipped or not")]
    public bool isEquiped = false;

    [Header("GameObject with sprite visual")]
    [SerializeField] private GameObject spriteVisual = null;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && isEquiped == false)
        {
            EquipTorch();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && isEquiped)
        {
            UnequipTorch();
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
}
