using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Run : State
{
    private readonly float maxXSpeed = 2f;
    public override void Enter()
    {
        anim.Play("Run");
    }

    public override void Do()
    {
        float velX = rb.velocity.x;
        anim.speed = Helpers.Map(Mathf.Abs(velX) * 2, 0, maxXSpeed, 0, 1.6f, true);
    }

    public override void FixedDo()
    {
    }
    public override void Exit()
    {
    }
}
