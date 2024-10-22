using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PlayerController : Core
{
    public State airState;
    public State runState;
    public State idleState;
    public State hurtState;
    public State deathState;
    public Transform pocket;

    public LifeManager lifeManager;

    private bool isHurt;
    public float xInput { get; private set; }
    public float yInput { get; private set; }

    public float maxSpeed { get; private set; }
    private readonly float friction = 1f;
    public float jumpSpeed { get; private set; }

    private bool isPassingThrough = false;

    private readonly float yThreshold = 0.2f;

    private readonly float passthroughTime = 0.5f;


    private int playerMaxLife = 9;

    private bool isDead;
    private bool isCollectingCatnip;

    public float ContactDirection { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        lifeManager.SetStartingLife(playerMaxLife);
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
        IsItDeadYet();
        if (state != hurtState && state != deathState)
        {
            GetInput();
            FaceInput();
            Move();
            CollectCatnip();
        }
        SelectState();


    }

    private void CollectCatnip()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            isCollectingCatnip = true;
        }
        else
        {
            isCollectingCatnip = false;
        }
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

        state?.FixedDoBranch();
    }

    void Move()
    {

        if (Mathf.Abs(xInput) > 0.01f)
        {
            rb.velocity = new Vector2(xInput * maxSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && groundSensor.isGrounded)
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
        if (state.isComplete)
        {
            if (state == hurtState)
            {
                isHurt = false;
                ContactDirection = 0;
            }
            if (groundSensor.isGrounded && rb.velocity.y <= yThreshold)
            {
                if (xInput == 0)
                {
                    Set(idleState);
                }
                else
                {
                    Set(runState);
                }
            }
            else
            {
                if (state != airState)
                    Set(airState);
            }
        }


        if (state != deathState)
        {
            if (state != hurtState && isHurt)
            {
                Set(hurtState, true);
            }
            if (isDead)
            {
                Set(deathState, true);
            }
        }

        state.DoBranch();
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

    private void Hurt()
    {
        if (!isHurt)
        {
            lifeManager.TakeDamage(1);
            isHurt = true;
            Debug.Log(lifeManager.LifeTotal);
        }
    }

    private void IsItDeadYet()
    {
        isDead = lifeManager.IsOutOfLives();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.CompareTag("Catnip"))
        {


            if (collisionGameObject.GetComponent<CatnipScript>().CanBeTake)
            {
                collision.transform.SetParent(pocket);
                collisionGameObject.SetActive(false);

            }


        }
        if (collisionGameObject.CompareTag("Squirrel"))
        {

            ContactDirection = Mathf.Sign(gameObject.transform.position.x - collisionGameObject.transform.position.x);

            Hurt();



        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.CompareTag("Dirt"))
        {
            if (isCollectingCatnip)
            {
                collisionGameObject.GetComponent<DirtScript>().ReleaseCatnip();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.CompareTag("Projectile"))
        {
            ContactDirection = Mathf.Sign(collisionGameObject.GetComponent<Rigidbody2D>().velocity.x);

            Hurt();



        }
    }

}
