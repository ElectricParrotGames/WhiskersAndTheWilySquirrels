using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class AirState : State
{

    public PlayerMovement input;
    public override void Enter()
    {
        anim.Play("Jump");
    }

    public override void Do()
    {

        float time = Helpers.Map(rb.velocity.y, -input.jumpSpeed, input.jumpSpeed, 0, 1, true);
        anim.Play("Jump", 0, time);
        anim.speed = 0;

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
