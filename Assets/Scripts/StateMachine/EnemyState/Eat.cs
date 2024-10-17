using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : State
{
    public Transform mouth;
    public Transform target;
    public override void Enter()
    {
        anim.Play("Eat");
        anim.speed = 0.5f;

        target.SetParent(mouth);
        target.gameObject.SetActive(false);
        target = null;
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
