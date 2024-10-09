using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Core : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GroundSensor groundSensor;

    public StateMachine machine;

    public State state => machine.state;

    protected void Set(State newState, bool forceReset = false)
    {
        machine.Set(newState, forceReset);
    }

    public void SetupInstances()
    {
        machine = new StateMachine();

        State[] allChildState = GetComponentsInChildren<State>();
        foreach (State state in allChildState)
        {
            state.SetCore(this);
        }
    }
}
