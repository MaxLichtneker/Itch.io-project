using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUi : MonoBehaviour
{
    //closes the seed selection UI if the player gets too far
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TurnOffUI();
        }
    }


    private void TurnOffUI()
    {
        gameObject.SetActive(false);
    }
}
