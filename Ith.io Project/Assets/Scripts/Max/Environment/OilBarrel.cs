using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OilBarrel : MonoBehaviour
{
    private Torch torch;

    [Header("text that shows up when in range of barrel")]
    [SerializeField] private TextMeshPro text = null;

    [Header("keeps track of the player entering and leaving the collider")]
    [SerializeField]private bool inCollider = false;

    void Start()
    {
        torch = FindObjectOfType<Torch>();
    }

    private void Update()
    {
        if (inCollider)
        {
            if (Input.GetKeyDown(KeyCode.F) && torch.timer < 0.0f)
            {
                torch.timer = torch.maxTimerValue;
            }
        }
    }

    //checks if the player is colliding and when the player presses F he refills the torch
    private void OnTriggerStay2D(Collider2D collision)
    {
        inCollider = true;

        if (collision.CompareTag("Player"))
        {
            inCollider = true;
            text.text = "Press F to refill torch";
        }
    }


    //when the player exits the collider the text will turn of
    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
        text.text = "";
    }

}
