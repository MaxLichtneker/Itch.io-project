using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    [Range(1,10)]
    private float speed = 4;

    public Vector3 targetPos;
    public bool moving = false;

    [Header("Animator of the player")]
    [SerializeField] private Animator animator = null;

    private GameManger gm;

    private SpriteRenderer spriteRenderer = null;

    private Rigidbody2D rig;

    private Plot[] plot;


    //public Vector3 maxMovementTopLeft;
    //public Vector3 maxMovementDownRight;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gm = GameManger.FindObjectOfType<GameManger>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetAnimatorValues();

        if (gm.ableToWalk)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetTargetPosition();
                FlipPlayer();
            }
        }
    }
    private void FixedUpdate()
    {
        if (gm.ableToWalk)
        {
            if (moving)
            {
                move();

            }
        }
    }
    private void SetTargetPosition()
    {
        // get the mouse postion on to the targetpos
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //ignore Z transfore
        targetPos.z = transform.position.z;

        

        moving = true;
    }
    private void move()
    {
        //rotate the player to the mouse
        //Vector2 direction = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y);
        //transform.up = direction;


        

        //moeve to the target position
        rig.MovePosition(Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime));
        

        
        
        //if it reaches the targetpos stop moving
        if(transform.position == targetPos)
        {
            moving = false;
        }
    }

    private void SetAnimatorValues()
    {
        if(animator != null)
        {
            animator.SetBool("walking", moving);
        }
    }

    public void SetSeedSelectionFalse()
    {
        if(animator != null)
        {
            animator.SetBool("Plant", false);
        }
    }

    //flips the player 
    private void FlipPlayer()
    {
        if(targetPos.x > 0.0f)
        {
            gameObject.transform.localScale = new Vector3(0.5f, .5f, .5f);
        }

        if(targetPos.x < 0.0f)
        {
            gameObject.transform.localScale = new Vector3(-0.5f, .5f, .5f);
        }
    }

    //stops the walking animation when the player walks against a wall
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.CompareTag("Fences"))
        {
            moving = false;
        }
    }

}
