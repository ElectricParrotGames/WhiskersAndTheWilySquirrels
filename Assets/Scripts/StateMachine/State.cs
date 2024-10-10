using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    
    public bool isComplete { get; protected set; }
    protected float startTime;
    public float time => Time.time - startTime;

    protected Rigidbody2D rb => core.rb;
    protected Animator anim => core.anim;
    protected Core core;

    public StateMachine machine;

    public StateMachine parent;
    public State state => machine.state;

    protected void Set(State newState, bool forceReset = false)
    {
        machine.Set(newState, forceReset);
    }

    public void SetCore(Core _core)
    {
        machine = new StateMachine();
        core = _core;
    }

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void DoBranch()
    {
        Do();
        if (state != null)
        {
            state.DoBranch();
        }
        
    }

    public void FixedDoBranch()
    {
        FixedDo();
        if(state != null)
        {
            state.FixedDoBranch();
        }
        
    }

    public void Initialise(StateMachine _parent)
    {
        parent = _parent;
        isComplete = false;
        startTime = Time.time;
    }

}
