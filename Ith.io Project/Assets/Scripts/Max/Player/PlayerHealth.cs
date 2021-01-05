using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,3)]
    [Header("amount of health the player has")]
    [SerializeField] private int health = 0;

    [Header("images of the health")]
    [SerializeField] private GameObject[] healthImages;

    void Start()
    {
        health = healthImages.Length;
    }

    void Update()
    {
    }

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

}
