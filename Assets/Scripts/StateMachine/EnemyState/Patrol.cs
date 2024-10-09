using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    public Navigate navigate;
    public IdleState idle;
    public Transform anchor1;
    public Transform anchor2;
    public override void Enter()
    {
        GoToNextDestination();
    }

    void GoToNextDestination()
    {
        float randomSpot = Random.Range(anchor1.position.x, anchor2.position.x);
        navigate.destination = new Vector2(randomSpot, core.transform.position.y);
        Set(navigate, true);
    }

    public override void Do()
    {
        if (machine.state == navigate)
        {
            if (navigate.isComplete)
            {
                Set(idle, true);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        else
        {
            if(machine.state.time > 1)
            {
                GoToNextDestination();
            }
        }
    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }
}
