using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : Detection
{
    public LayerMask playerLayerMask;
    public LayerMask groundMask;
    public float playerViewDistance = 1.4f;
    public float fovAngle;

    private float timer = 0f;
    private float minTime = 3f;

    // Update is called once per frame
    void Update()
    {
        UpdateDetection();
        timer += Time.deltaTime;

        if (timer >= minTime)
        {
            Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(position, playerViewDistance, playerLayerMask);

            foreach (Collider2D target in targetsInViewRadius)
            {
                Vector2 directionToTarget = (target.transform.position - position).normalized;
                float angleBetween = Vector2.Angle(viewPosition, directionToTarget);

                // Check if the target is within the field of view angle
                if (angleBetween < fovAngle / 2)
                {
                    float distanceToTarget = Vector2.Distance(position, target.transform.position);

                    // Check if there's an obstacle in the way
                    if (!Physics2D.Raycast(position, directionToTarget, distanceToTarget, groundMask))
                    {
                        EnemyController scriptEnemy = transform.parent.GetComponent<EnemyController>();
                        if (!scriptEnemy.hasPlayerTarget)
                        {
                            timer = 0;
                            scriptEnemy.hasPlayerTarget = true;
                            scriptEnemy.attack.target = target.transform;
                        }
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the FOV
        Gizmos.color = Color.yellow;
        Vector3 leftBoundary = Quaternion.Euler(0, 0, fovAngle / 2) * viewPosition * playerViewDistance;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -fovAngle / 2) * viewPosition * playerViewDistance;

        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        // Draw the view radius
        Gizmos.DrawWireSphere(transform.position, playerViewDistance);
    }
}
