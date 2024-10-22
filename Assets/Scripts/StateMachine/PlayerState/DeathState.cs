using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeathState : State
{
    public override void Enter()
    {
        anim.Play("Sleep");
        anim.speed = 0.5f;
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
