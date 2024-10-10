using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public override void Enter()
    {
        anim.Play("Idle");
        anim.speed = 1;
    }

    public override void Do()
    {

    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }
}
