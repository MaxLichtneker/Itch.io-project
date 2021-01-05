using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,3)]
    [Header("amount of health the player has")]
    [SerializeField] private int health = 0;

    [Header("images of the health")]
    [SerializeField] private GameObject[] healthImages = null;

    [Header("panel that activates when the player dies")]
    [SerializeField] private GameObject deathPanel = null;

    void Start()
    {
        health = healthImages.Length;
    }

    void Update()
    {
        CheckHealthStatus();
    }

    //when the player collides with an enemy his health will drop and an image in the array will be turned off
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health--;
                healthImages[health].SetActive(false);
            }
        }
    }

    //checks if the health is below 0
    private void CheckHealthStatus()
    {
        if(health <= 0)
        {
            Time.timeScale = 0.0f;

            deathPanel.SetActive(true);
        }
    }

}
