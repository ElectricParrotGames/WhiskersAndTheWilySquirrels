using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public PlayerMovement input;
    public override void Enter()
    {
        anim.Play("Idle1");
    }

    public override void Do()
    {
        if(!core.groundSensor || input.xInput != 0){
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