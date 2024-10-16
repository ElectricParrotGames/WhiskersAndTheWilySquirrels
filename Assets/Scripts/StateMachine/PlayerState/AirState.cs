using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class AirState : State
{

    public PlayerMovement input;
    public override void Enter()
    {
        if(rb.velocity.y >= 0)
        {
            anim.Play("Jump");
            anim.speed = 0.5f;
        }
        else
        {
            anim.Play("Fall");
            anim.speed = 0.5f;
        }
    }

    public override void Do()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && rb.velocity.y < 0)
        {
            
            anim.Play("Fall");
            anim.speed = 0.5f;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fall") && rb.velocity.y >= 0)
        {

            anim.Play("Jump");
            anim.speed = 0.5f;
        }


        if (core.groundSensor.isGrounded)
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
