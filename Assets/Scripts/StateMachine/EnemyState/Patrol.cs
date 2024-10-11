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
    public bool hasAnchor;

    private void Start()
    {
        hasAnchor = (anchorLeft != null && anchorRigth != null);
        Debug.Log(hasAnchor);
    }
    public override void Enter()
    {
        GoToNextDestination();
    }

    void GoToNextDestination()
    {
        float randomSpot;
        if (!hasAnchor)
        {
            randomIdleTime = Random.Range(5f, 7.5f);
            randomSpot = Random.Range(core.transform.position.x - 0.1f, core.transform.position.x + 0.1f);
            navigate.destination = new Vector2(randomSpot, core.transform.position.y);
        }
        else
        {
            randomIdleTime = Random.Range(0.5f, 1.5f);
            randomSpot = Random.Range(anchorLeft.position.x, anchorRigth.position.x);
            navigate.destination = new Vector2(randomSpot, core.transform.position.y);
        }
        
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
