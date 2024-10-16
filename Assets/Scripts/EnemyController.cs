using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : Core
{
    [SerializeReference]private Transform collectTransform;
    public Patrol patrol;
    public Collect collect;
    public Hurt hurt;
    public Attack attack;
    public PlayerDetection playerDetection;
    private bool isHurt = false;
    [SerializeReference] private Archetype archetype;

    private void Awake()
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
                if (state == collect)
                {
                    Set(patrol);
                }
                if (state == attack)
                {
                    Set(patrol);
                }
            }
            if (state == patrol)
            {
                collect.CheckForTarget();

                if (collect.target != null)
                {
                    Set(collect);
                }
            }
            if (state != attack && playerDetection.PlayerInView)
            {
                Set(attack);
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

            attack.minTime = archetype.minTimeBetweenThrow;
            attack.throwMethod = archetype.throwMethod;

            //TODO when split attack state
            if (archetype.canThrow)
            {
                
            }

            if (archetype.canChase)
            {
                
            }
            
        }
        else
        {
            attack = null;
        }
    }

}
