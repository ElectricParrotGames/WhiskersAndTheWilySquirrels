using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : State
{
    public override void Enter()
    {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            anim.Play("Eat");
            anim.speed = 0.5f;
        }
        else
        {
            anim.Play("Bury");
            anim.speed = 0.75f;
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
