using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,3)]
    [Header("amount of health the player has")]
    [SerializeField] private float health = 0.0f;

    [Header("images of the health")]
    [SerializeField] private GameObject[] healthImages;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            health--;
        }
    }
}
