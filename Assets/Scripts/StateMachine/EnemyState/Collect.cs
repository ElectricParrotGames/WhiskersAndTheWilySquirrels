using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : State
{
    public List<Transform> catnips;
    public Transform target;
    public Navigate navigate;
    public Take take;
    public Idle idle;
    public float collectRadius;
    public Transform mouth;
    public BoxCollider2D visionCollider;

    public override void Enter()
    {
        navigate.destination = target.position;
        Set(navigate, true);
    }

    public override void Do()
    {
        if(state == navigate)
        {
            if (CloseEnough(target.position))
            {
                target.SetParent(mouth);
                target.gameObject.SetActive(false);
                rb.velocity = new Vector2(0, rb.velocity.y);
                Set(take, true);
                return;
            }
            else if (!InVision(target.position))
            {
                Set(idle, true);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else
            {
                navigate.destination = target.position;
                Set(navigate, true);
            }
        }
        else
        {
            if(state.time > 2)
            {
                isComplete = true;
            }
        }

        if(target == null)
        {
            isComplete = true;
            return;
        }

    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }

    public bool CloseEnough(Vector2 targetPos)
    {
        return Vector2.Distance(core.transform.position, targetPos) < collectRadius;
    }

    public bool InVision(Vector2 targetPos)
    {
        return visionCollider.OverlapPoint(targetPos);
    }

    public void CheckForTarget()
    {
        foreach (Transform catnip in catnips)
        {
            if (InVision(catnip.position) && catnip.gameObject.activeSelf)
            {
                target = catnip;
                return;
            }
        }
        target = null;
    }
}
