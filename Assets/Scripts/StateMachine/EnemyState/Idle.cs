using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    
    public override void Enter()
    {
        int randomNumber = Random.Range(0, 2);
        if(randomNumber == 0)
        {
            anim.Play("Idle");
            anim.speed = 1;
        }
        else
        {
            anim.Play("Look");
            anim.speed = 0.5f;
        }
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
