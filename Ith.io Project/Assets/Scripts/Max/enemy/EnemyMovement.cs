using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("speed of the enemy")]
    [SerializeField] private float enemySpeed = 0.0f;

    [Header("distance between the enemy and the player")]
    [SerializeField] private float distance = 0.0f;

    [Header("the transform of the player")]
    private GameObject playerTransform = null;

    private Torch torch;

    private GameObject targetPosition;

    private void Start()
    {
        torch = FindObjectOfType<Torch>();

        targetPosition = GameObject.Find("Player");

        playerTransform = GameObject.Find("Player");
    }

    void Update()
    {
        Movement();

        if (torch.isEquiped)
        {
            AfraidOfTorch();
        }
    }

    //moves the enemy towards the player
    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.gameObject.transform.position, enemySpeed * Time.deltaTime);
    }

    //moves the enemy away from the player
    private void AfraidOfTorch()
    {
       distance = Vector3.Distance(gameObject.transform.position, playerTransform.transform.position);

        if(distance > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition.gameObject.transform.position, -enemySpeed * 1.5f * Time.deltaTime);
        }
        else if(distance > 10.0f)
        {
            enemySpeed = 0.0f;
        }
    }

}
