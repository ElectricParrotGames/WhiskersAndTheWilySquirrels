using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeathState : State
{
    private float timer;
    private float maxTime = 2f;
    public override void Enter()
    {
        anim.Play("Sleep");
        anim.speed = 0.5f;
        timer = maxTime;
        rb.velocity = new Vector2(0, rb.velocity.y);
        UIManager.instance.ActivateGameOverPanel(true);
    }

    public override void Do()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            UIManager.instance.ActivateGameOverPanel(false);
            LevelNavigator.instance.ReloadScene();
        }
    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }
}
