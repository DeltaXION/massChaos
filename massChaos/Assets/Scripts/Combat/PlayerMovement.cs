using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    dash
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;

    public float dashSpeedMultiplier;
    //public float dashDistance;
    private float dashTime;
   // public float startDashTime;
    

    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        CheckAttackOrWalk();
        
        Debug.Log(change);
    }

    void GetInput()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        
        
    }

    void CheckAttackOrWalk()
    {
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (Input.GetButtonDown("dash") && currentState != PlayerState.dash)
        {
            StartCoroutine(DashCo());
            //HandleDash();
           // Dash(dashDistance, dashSpeed, change);
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.2f);
        currentState = PlayerState.walk;
    }

    private IEnumerator DashCo()
    {
        animator.SetBool("dashing", true);
        change.Normalize();
        currentState = PlayerState.dash;
        myRigidbody.velocity =/* transform.position + */change * dashSpeedMultiplier * speed;
        //change = Vector3.zero;
        yield return null;
        animator.SetBool("dashing", false);
        yield return new WaitForSeconds(0.2f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            myRigidbody.velocity = Vector3.zero;
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
       // if (Input.GetButton("dash"))// && (dashTime != 0))
       // {        
      //      HandleDash();
       // } 
        
    }

    void HandleDash()
    {
       // change.Normalize();
       // myRigidbody.velocity = Vector3.zero;
       // myRigidbody.velocity += new Vector2(x, y).normalized * dashDistance;
        //currentState = PlayerState.dash;
        //myRigidbody.AddForce(change * dashDistance);
       // myRigidbody.MovePosition(transform.position + (change * (dashSpeedMultiplier * speed)) * Time.deltaTime); 
       // StartCoroutine(DashCo());
    }

   

   
}
