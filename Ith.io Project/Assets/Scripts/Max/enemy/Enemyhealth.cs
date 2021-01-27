using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    [SerializeField] private float health = 1.0f;

    private void Update()
    {
        CheckHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fist"))
        {
            health -= 1;
        }
    }

    private void CheckHealth()
    {
        if(health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
    
}
