using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [Header("The animator that belongs to the player")]
    [SerializeField]private Animator playerAnim = null;

    private BoxCollider2D boxCollider;

    [Header("checks if the player selected the enemy")]
    [SerializeField] private bool enemySelected = false;

    [SerializeField]private bool clickedOther = false;

    [Header("Checks the distance between the player and the enemy")]
    [SerializeField] private float distance = 0.0f;

    private GameObject selectedEnemy = null;

    Vector3 mousePos;

    void Update()
    {
        CalculateDistance();

        CheckIfClicking();

        Attack();
    }

    private void CheckIfClicking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            
            if(hit.collider.CompareTag("Enemy") && !enemySelected)
            {
                enemySelected = true;

                selectedEnemy.transform.position = hit.transform.position;
            }
            else if(hit.collider)
            {
                enemySelected = false;
            }

        }
    }

    private void CalculateDistance()
    {
        if(selectedEnemy != null)
        {
            distance = Vector2.Distance(gameObject.transform.position, selectedEnemy.transform.position);
        }
    }

    private void Attack()
    {
        if(enemySelected)
        {
            playerAnim.SetTrigger("Attack");
        }
    }
    

    public IEnumerator PlayerCollider()
    {
        gameObject.GetComponentInChildren<CircleCollider2D>().enabled = true;

        yield return new WaitForSeconds(.2f);

        gameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;
    }

}
