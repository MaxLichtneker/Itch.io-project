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

    private BoxCollider2D boxCollider;

    private Torch torch;

    private GameObject targetPosition;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        torch = FindObjectOfType<Torch>();

        targetPosition = GameObject.Find("Player");

        playerTransform = GameObject.Find("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, playerTransform.transform.position);

        Movement();

        AttackPlayer();

        if (torch.isEquiped && torch.timer > 0.0f)
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
        if(distance > 0.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition.gameObject.transform.position, -enemySpeed * 1.5f * Time.deltaTime);
        }
    }

    private void AttackPlayer()
    {
        if(distance < 1.35)
        {
            StartCoroutine(AttackDelay());
        }
    }


    private IEnumerator AttackDelay()
    {
        boxCollider.enabled = true;

        yield return new WaitForSeconds(.40f);

        boxCollider.enabled = false;

    }
}
