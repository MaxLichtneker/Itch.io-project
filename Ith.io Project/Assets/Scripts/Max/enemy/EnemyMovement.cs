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

    private BoxCollider2D boxCollider = null;

    private Torch torch;

    private GameObject targetPosition;

    public Animator enemyAnimator = null;

    [SerializeField]private bool startAttack = false;

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

        if (!startAttack)
        {
            Movement();
        }

        AttackPlayer();

        if (startAttack)
        {
            enemyAnimator.SetTrigger("attack");
        }

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
        if(distance < 2.0f)
        {
            startAttack = true;
        }
    }

    //sets the startattack bool to false in the animation
    public void TurnOffAttack()
    {
        startAttack = false;
    }

    public IEnumerator AttackDelay()
    {
        
        boxCollider.enabled = true;

        yield return new WaitForSeconds(.2f);

        boxCollider.enabled = false;
    }
}
