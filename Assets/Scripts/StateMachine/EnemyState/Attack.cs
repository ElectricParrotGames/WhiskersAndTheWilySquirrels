using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attack : State
{
    public GameObject prefabAcorn;
    public Transform nutLauncher;
    public Transform target;
    private float speed = 5;
    private bool canShot;

    public override void Enter()
    {
        anim.Play("Attack");
        anim.speed = 1;
        canShot = true;
    }

    public override void Do()
    {
        if (!canShot)
        {
            isComplete = true;
        }
    }

    public override void FixedDo()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Shot();
            isComplete = true;
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

        // Highest shot with the given max speed:
        float T_max = Mathf.Sqrt((b + discRoot) * 2f / gSquared);

        // Most direct shot with the given max speed:
        float T_min = Mathf.Sqrt((b - discRoot) * 2f / gSquared);

        // Lowest-speed arc available:
        float T_lowEnergy = Mathf.Sqrt(Mathf.Sqrt(toTarget.sqrMagnitude * 4f / gSquared));

        // Choose T (for example, you could use T_max):
        float T = T_lowEnergy; // or T_min, or T_lowEnergy, depending on your needs

        // Convert from time-to-hit to a launch velocity:
        Vector2 velocity = toTarget / T - Physics2D.gravity * T / 2f;

        GameObject projectile = Instantiate(prefabAcorn, nutLauncher.position, nutLauncher.rotation);
        // Apply the calculated velocity (using AddForce2D with ForceMode2D.Impulse)
        projectile.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
        
    }
}
