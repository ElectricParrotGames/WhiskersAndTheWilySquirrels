using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;
    protected PlayerMovement input;
    public bool isComplete { get; protected set; }
    protected float startTime;
    public float time => Time.time - startTime;

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void Setup(Rigidbody2D _rb, Animator _animator, PlayerMovement _playerMovement)
    {
        rb = _rb;
        anim = _animator;
        input = _playerMovement;
    }

}
