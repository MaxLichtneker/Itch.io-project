﻿using System.Collections;
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
        animator.SetBool("walking", moving);
    }

    private void FlipPlayer()
    {
        if(targetPos.x > 0.0f)
        {
            spriteRenderer.flipX = false;
        }

        if(targetPos.x < 0.0f)
        {
            spriteRenderer.flipX = true;
        }
    }

}
