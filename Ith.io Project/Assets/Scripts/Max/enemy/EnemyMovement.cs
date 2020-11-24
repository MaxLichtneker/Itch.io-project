using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 0.0f;

    private GameObject targetPosition;

    private void Start()
    {
        targetPosition = GameObject.Find("Player");
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.gameObject.transform.position, enemySpeed * Time.deltaTime);
    }
}
