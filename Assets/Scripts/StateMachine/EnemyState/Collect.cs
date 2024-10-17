using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : State
{
    public List<Transform> catnips;
    public Transform target;
    public Navigate navigate;
    public Idle idle;
    public Bury bury;
    public Eat eat;
    private readonly float collectRadius = 0.2f;
    public Transform mouth;
    public CatnipDetection catnipDetection;

    private void Start()
    {
        navigate.Speed = 1f;
    }

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
                rb.velocity = new Vector2(0, rb.velocity.y);
                int randomNumber = 3;
                if (bury != null && eat != null)
                {
                    randomNumber = Random.Range(0, 2);
                }
                
                if((bury != null && eat == null) || randomNumber == 0){
                    bury.target = target;
                    Set(bury, true);
                }
                else if((eat != null && bury == null) || randomNumber == 1)
                {
                    eat.target = target;
                    Set(eat, true);
                }
                
                
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

    public bool InVision(Vector3 targetPos)
    {
        return catnipDetection.IsCatnipAccessible(targetPos);
    }

    public void CheckForTarget()
    {
        foreach (Transform catnip in catnips)
        {
            if (InVision(catnip.position) && catnip.gameObject.activeSelf && catnip.GetComponent<CatnipScript>().CanBeTake)
            {
                target = catnip;
                return;
            }
        }
        target = null;
    }
}
