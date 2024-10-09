using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : Core
{
    public State airState;
    public State runState;
    public State idleState;

    public float xInput { get; private set; }
    public float yInput { get; private set; }

    public float maxSpeed { get; private set; }
    public float jumpSpeed { get; private set; }

    private bool canPassThrough = false;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 1f;
        jumpSpeed = 3f;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        SetupInstances();
        machine.Set(idleState);

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        FaceInput();
        Move();
        SelectState();
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

        if (Input.GetKeyDown(KeyCode.Space) && groundSensor.isGrounded)
        { 
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (yInput <0 && canPassThrough){
            Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Platform"),false);

        }
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void SelectState()
    {
        State oldState = machine.state;

        if (groundSensor.isGrounded)
        {
            if (xInput == 0)
            {
                machine.Set(idleState);
            }
            else
            {
                machine.Set(runState);
            }
        }
        else
        {
            machine.Set(airState);
        }
    }

    void FaceInput()
    {
        float direction = Mathf.Sign(xInput);
        if(xInput != 0)
        {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    //Passthrough related
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            canPassThrough = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            canPassThrough = false;
        }
    }
}
