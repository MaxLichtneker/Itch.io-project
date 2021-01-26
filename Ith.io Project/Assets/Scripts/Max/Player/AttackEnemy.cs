using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [Header("The animator that belongs to the player")]
    private Animator playerAnim = null;

    private GameObject playerGameObject;

    private BoxCollider2D boxCollider;

    [Header("checks if the player selected the enemy")]
    [SerializeField] private bool enemySelected = false;

    [SerializeField]private bool clickedOther = true;

    [Header("Checks the distance between the player and the enemy")]
    [SerializeField] private float distance = 0.0f;


    void Start()
    {
        playerGameObject = GameObject.Find("Player");

        playerAnim = playerGameObject.GetComponent<Animator>();

        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        CalculateDistance();

        CheckIfClickingOther();

        Attack();
    }

    private void OnMouseDown()
    {
        if (!enemySelected && clickedOther)
        {
            clickedOther = false;
            enemySelected = true;
        }
    }

    private void CheckIfClickingOther()
    {
        if (Input.GetMouseButtonDown(0) && !clickedOther && enemySelected)
        {
            clickedOther = true;
            enemySelected = false;
        }
    }

    private void CalculateDistance()
    {
        distance = Vector2.Distance(gameObject.transform.position, playerGameObject.transform.position);
    }

    private void Attack()
    {
        if(distance < 3.25 && enemySelected)
        {
            playerAnim.SetTrigger("Attack");

            StartCoroutine(PlayerCollider());
        }
    }
    

    public IEnumerator PlayerCollider()
    {
        yield return new WaitForSeconds(1.5f);

        playerGameObject.GetComponentInChildren<CircleCollider2D>().enabled = true;

        yield return new WaitForSeconds(.4f);

        playerGameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;
    }

}
