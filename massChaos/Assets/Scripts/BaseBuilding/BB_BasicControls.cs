using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_BasicControls : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator animator;

    bool stopMovement;

    public Vector2 MaxPlayerBoundary, MinPlayerBoundary;
    private Vector2 TargetPosition, TargetPositionClick, temp;

    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsCursorClickPosition(); // Basic Movement towards cursor click
        SetUpBoundaries();  //Boundary Limit for the Player Movement 
    }

    private void MoveTowardsCursorClickPosition()
    {
        
        // Get Cursor Position
       if (Input.GetMouseButtonDown(0))
       {
           TargetPositionClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           stopMovement = false;
       }

       // Stop Movement Bug (HUMPING)
       if (stopMovement == true)
       {
           return;
       }


       // Move towards Cursor
        myRigidbody.transform.position = Vector2.MoveTowards(transform.position, TargetPositionClick, speed * Time.deltaTime);
    }

    private void SetUpBoundaries()
    {
        TargetPosition.x = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, MinPlayerBoundary.x, MaxPlayerBoundary.x);
        TargetPosition.y = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, MinPlayerBoundary.y, MaxPlayerBoundary.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        stopMovement = true;
    }




}
