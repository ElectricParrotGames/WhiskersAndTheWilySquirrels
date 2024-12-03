using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : Core
{
    public Patrol patrol;
    public Collect collect;
    public Hurt hurt;
    public Attack attack;
    public PlayerDetection playerDetection;

    private float playerBounce = 1.75f;
    private bool isHurt = false;
    [SerializeReference] private Archetype archetype;

    private void Awake()
    {
        transform.SetParent(null);
        SetBehaviour();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupInstances();
        Set(patrol);
    }

    // Update is called once per frame
    void Update()
    {
        if(state != hurt)
        {
            if (state.isComplete)
            {
                if (collect != null && state == collect)
                {
                    Set(patrol);
                }
                if (attack != null && state == attack)
                {
                    Set(patrol);
                }
            }
            if (state == patrol)
            {
                if(collect != null)
                {
                    collect.CheckForTarget();

                    if (collect.target != null)
                    {
                        Set(collect);
                    }
                }
              
            }
            if (attack != null && state != attack && playerDetection.PlayerInView)
            {
                Set(attack, true);
            }

            if (isHurt)
            {
                Set(hurt, true);
            }
        }
        
        state.DoBranch();
    }

    private void FixedUpdate()
    {
        state.FixedDoBranch();
    }

    public void Hurt()
    {
        isHurt = true;
        GetComponentInChildren<BoxCollider2D>().gameObject.SetActive(false);
    }

    private void SetBehaviour()
    {
        if (archetype.needBehaviour)
        {
            SetPatrol();
            SetCollect();
            SetAttack();
        }
        else
        {
            collect = null;
            attack = null;
            patrol.anchorLeft = null;
            patrol.anchorRigth = null;
        }
    }

    private void SetPatrol()
    {
        if (archetype.canPatrol)
        {
            patrol.navigate.Speed = archetype.patrolSpeed;
        }
        else
        {
            patrol.anchorLeft = null;
            patrol.anchorRigth = null;
        }
    }

    private void SetCollect()
    {
        if (archetype.canCollect)
        {
            collect.navigate.Speed = archetype.collectSpeed;
            if (!archetype.canBury)
            {
                collect.bury = null;
            }
            if (!archetype.canEat)
            {
                collect.eat = null;
            }
        }
        else
        {
            collect = null;
        }
    }

    private void SetAttack()
    {
        if (archetype.canAttack)
        {

            if (archetype.canThrow)
            {
                attack.minTimeBetweenAttack = archetype.minTimeBetweenAttack;
                attack.throws.throwMethod = archetype.throwMethod;
            }
            else
            {
                attack.throws = null;
            }

            if (archetype.canChase)
            {
                attack.chase.Speed = archetype.chaseSpeed;
            }
            else
            {
                attack.chase = null;
            }

        }
        else
        {
            attack = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
           
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null && playerRb.velocity.y < 0) 
            {
               
                Hurt();
               
                playerRb.velocity = new Vector2(playerRb.velocity.x, playerBounce);
                Physics2D.IgnoreCollision(collision.transform.root.GetComponent<CircleCollider2D>(), gameObject.GetComponentInChildren<BoxCollider2D>());
            }
        }
    }

    
}
