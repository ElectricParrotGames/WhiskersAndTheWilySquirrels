using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{

    public PlayerController input;
    public override void Enter()
    {
        anim.Play("Walk");
    }

    public override void Do()
    {
        float velX = rb.velocity.x;
        anim.speed = Helpers.Map(input.maxSpeed, 0, 1, 0, 1f, true);


        if(!core.groundSensor.isGrounded || input.xInput == 0)
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
