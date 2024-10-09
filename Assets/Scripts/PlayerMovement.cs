using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public State airState;
    public State runState;
    public State idleState;
    State state;

    public float xInput { get; private set; }
    public float yInput { get; private set; }

    public float maxSpeed { get; private set; }
    public float jumpSpeed { get; private set; }

    public bool isGrounded { get; private set; }
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 1f;
        jumpSpeed = 3f;
        isGrounded = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        idleState.Setup(rb, anim, this);
        airState.Setup(rb, anim, this);
        runState.Setup(rb, anim, this);

        state = idleState;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        FaceInput();
        Move();
        CheckGround();
        if (state.isComplete)
        {
            SelectState();
        }
        state.Do();
    }
    private void FixedUpdate()
    {
        
    }

    void Move()
    {
        
        if(Mathf.Abs(xInput) > 0)
        {
            rb.velocity = new Vector2(xInput * maxSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    void SelectState()
    {
        if (isGrounded)
        {
            if (xInput == 0)
            {
                state = idleState;
            }
            else
            {
                state = runState;
            }
        }
        else
        {
            state = airState;
        }
        state.Enter();
    }

    void FaceInput()
    {
        float direction = Mathf.Sign(xInput);
        if(xInput != 0)
        {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }
}
