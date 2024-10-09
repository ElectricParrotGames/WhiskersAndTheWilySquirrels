using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    
    public bool isComplete { get; protected set; }
    protected float startTime;
    public float time => Time.time - startTime;

    protected Rigidbody2D rb => core.rb;
    protected Animator anim => core.anim;
    protected Core core;

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void SetCore(Core _core)
    {
        core = _core;
    }

    public void Initialise()
    {
        isComplete = false;
        startTime = Time.time;
    }

}