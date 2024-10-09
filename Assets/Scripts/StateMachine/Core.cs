using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Core : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public PlayerMovement input;

    public StateMachine machine;

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
