using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public EnemyController input;
    public override void Enter()
    {
        anim.Play("Idle");
    }

    public override void Do()
    {
        if (!core.groundSensor)
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
