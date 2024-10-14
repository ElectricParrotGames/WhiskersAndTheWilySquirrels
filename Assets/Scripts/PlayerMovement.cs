using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    private readonly float friction = 1f;
    public float jumpSpeed { get; private set; }
    private bool isPassingThrough = false;

    private readonly float yThreshold = 0.2f;

    private readonly float passthroughTime = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 1f;
        jumpSpeed = 3.5f;

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
        if (yInput < 0)
        {
            FallThroughPlatform();
        }

        if (Mathf.Abs(xInput) < 0.01f && groundSensor.isGrounded && !isPassingThrough)
        {
            ApplyFriction();
        }
    }

    void Move()
    {

        if (Mathf.Abs(xInput) > 0.01f)
        {
            rb.velocity = new Vector2(xInput * maxSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundSensor.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    void SelectState()
    {
        State oldState = machine.state;

        if (groundSensor.isGrounded && rb.velocity.y <= yThreshold)
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
        if (xInput != 0)
        {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    private void FallThroughPlatform()
    {
        isPassingThrough = true;
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Platform"), true);
        StartCoroutine(ResetLayerCollision());
    }

    private IEnumerator ResetLayerCollision()
    {
        yield return new WaitForSeconds(passthroughTime);
        isPassingThrough = false;
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Platform"), false);
    }
    void ApplyFriction()
    {
        // Calculate the friction force based on current velocity
        Vector2 frictionForce = -rb.velocity.normalized * friction;

        // Apply the friction force
        rb.AddForce(frictionForce);

        // Stop the object if the friction brings it close to zero
        if (rb.velocity.magnitude < friction)
        {
            rb.velocity = Vector2.zero; // Stop movement
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HurtHitbox"))
        {
            if (rb.velocity.y < 0)
            {
                collision.gameObject.GetComponentInParent<EnemyController>().Hurt();
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed/2);
                Physics2D.IgnoreCollision(collision.transform.root.GetComponent<CircleCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
            }
        }
    }
}
