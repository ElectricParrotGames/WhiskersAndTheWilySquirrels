using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attack : State
{
    public GameObject prefabAcorn;
    public Transform nutLauncher;
    public Transform target;
    private readonly float speed = 5;
    private bool canShot;
    public PlayerDetection playerDetection;
    public ThrowMethod throwMethod = ThrowMethod.MIN_SPEED;

    private float timer;
    public float minTime = 3f;

    private void Start()
    {
        timer = minTime;
    }

    public override void Enter()
    {
        anim.Play("Idle");
        anim.speed = 1;
    }

    public override void Do()
    {
        target = playerDetection.TargetTransform;
        timer += Time.deltaTime;
        if(timer >= minTime)
        {
            canShot = true;
        }
        if (canShot)
        {
            timer = 0f;
            anim.Play("Attack");
        }
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.Play("Idle");
            }
        }
        if(target == null)
        {
            isComplete = true;
        }
    }

    public override void FixedDo()
    {
        if (canShot)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Shot();
                canShot = false;
            }
        }
        
    }
    public override void Exit()
    {

    }

    private void Shot()
    {
        // Get the target position relative to the projectile's position.
        Vector2 toTarget = target.position - nutLauncher.position;

        // Set up the terms needed to solve the quadratic equations.
        float gSquared = Physics2D.gravity.sqrMagnitude;
        float b = speed * speed + Vector2.Dot(toTarget, Physics2D.gravity);
        float discriminant = b * b - gSquared * toTarget.sqrMagnitude;

        // Check whether the target is reachable at max speed or less.
        if (discriminant < 0)
        {
            canShot = false;
            return;
        }

        float discRoot = Mathf.Sqrt(discriminant);
        float T;

        if(throwMethod == ThrowMethod.DIRECT)
        {
            float T_min = Mathf.Sqrt((b - discRoot) * 2f / gSquared);
            T = T_min;
        }
        else if(throwMethod == ThrowMethod.LOBE)
        {
            float T_max = Mathf.Sqrt((b + discRoot) * 2f / gSquared);
            T = T_max;
        }
        else if(throwMethod == ThrowMethod.MIN_SPEED){
            float T_lowEnergy = Mathf.Sqrt(Mathf.Sqrt(toTarget.sqrMagnitude * 4f / gSquared));
            T = T_lowEnergy;
        }
        else
        {
            canShot = false;
            return;
        }

        // Convert from time-to-hit to a launch velocity:
        Vector2 velocity = toTarget / T - Physics2D.gravity * T / 2f;

        GameObject projectile = Instantiate(prefabAcorn, nutLauncher.position, nutLauncher.rotation);
        // Apply the calculated velocity (using AddForce2D with ForceMode2D.Impulse)
        projectile.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
        
    }
}
