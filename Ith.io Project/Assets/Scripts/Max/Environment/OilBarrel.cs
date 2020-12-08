using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OilBarrel : MonoBehaviour
{
    private Torch torch;

    [Header("text that shows up when in range of barrel")]
    [SerializeField] private TextMeshPro text;

    void Start()
    {
        torch = FindObjectOfType<Torch>();
    }

    //checks if the player is colliding and when the player presses F he refills the torch
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.text = "Press F to refill torch";

            if (Input.GetKeyDown(KeyCode.F) && torch.timer < 0.0f)
            {
                torch.timer = torch.maxTimerValue;
            }
        }
    }


    //when the player exits the collider the text will turn of
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.text = "";
    }

}
