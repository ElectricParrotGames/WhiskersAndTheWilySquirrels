using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    private float randomIdleTime;
    public Navigate navigate;
    public Idle idle;
    public Transform anchorLeft;
    public Transform anchorRigth;
    public override void Enter()
    {
        GoToNextDestination();
    }

    void GoToNextDestination()
    {
        randomIdleTime = Random.Range(0.5f, 1.5f);
        float randomSpot = Random.Range(anchorLeft.position.x, anchorRigth.position.x);
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
            if(machine.state.time > randomIdleTime)
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
