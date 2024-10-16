using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Navigate : State
{
    public Vector2 destination;
    public float Speed { get; set; } = 0.5f;
    private readonly float threshold = 0.15f;
    private readonly float jumpSpeed = 50f;
    public State animationState;
    public WallDetection detection;
    public GroundSensor groundSensor;
    public FallDetection fallDetection;

    public override void Enter()
    {
        Set(animationState, true);
    }

    public override void Do()
    {
        if (Mathf.Abs(core.transform.position.x - destination.x) < threshold || 
            (!detection.CanBeJump && detection.IsTargetBehindWall(destination)) || 
            !fallDetection.CanFall)
        {
            isComplete = true;
        }
        FaceDestination();
    }

    public override void FixedDo()
    {
        float direction = Mathf.Sign(destination.x - core.transform.position.x);
        rb.velocity = new Vector2(direction * Speed, rb.velocity.y);

        if (groundSensor.isGrounded && detection.CanBeJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);

        }
    }
    public override void Exit()
    {

    }

    private void FaceDestination()
    {
        core.transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 1);
    }
}
