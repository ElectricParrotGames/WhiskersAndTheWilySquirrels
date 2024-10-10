using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State state;

    public void Set(State newState, bool forceReset = false)
    {
        if(state != newState || forceReset)
        {
            if (state != null) { 
                state.Exit();
            }
            state = newState;
            state.Initialise(state.machine);
            state.Enter();
        }
    }
}
