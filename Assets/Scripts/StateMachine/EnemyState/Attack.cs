using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attack : State
{
    
    public PlayerDetection playerDetection;
    public Throw throws;
    public Chase chase;
    public Transform target;
    private float timer;
    public float minTimeBetweenAttack = 3f;

    private void Start()
    {
        timer = minTimeBetweenAttack;
    }

    public override void Enter()
    {
        anim.Play("Idle");
        anim.speed = 1;
    }

    public override void Do()
    {
        target = playerDetection.TargetTransform;
        timer += Time.deltaTime;

        if (state != null && state == chase && state.isComplete)
        {
            target = null;
        }
        else if(timer >= minTimeBetweenAttack)
        {
            timer = 0;

            int randomNumber = 3;
            if (throws != null && chase != null)
            {
                randomNumber = Random.Range(0, 2);
            }

            if ((throws != null && chase == null) || randomNumber == 0)
            {
                throws.target = target;
                Set(throws, true);
            }
            else if(chase != null && throws == null || randomNumber == 1)
            {
                chase.destination = target.position;
                Set(chase, true);
            }
        }
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.Play("Idle");
            }
        }

        if (target == null)
        {
            isComplete = true;
        }
    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }
        
    
}
