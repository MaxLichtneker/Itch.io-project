using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    [Range(1,10)]
    private float speed = 4;

    private Vector3 targetPos;
    private bool moving = false;


    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }
        if (moving)
        {
            move();
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
        Vector2 direction = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y);
        transform.up = direction;

        //moeve to the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //if it reaches the targetpos stop moving
        if(transform.position == targetPos)
        {
            moving = false;
        }
    }

}
