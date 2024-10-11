using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionView : MonoBehaviour
{
    public float detectionDistance = 1.4f; // Distance to check for players
    public LayerMask playerLayer; // Layer that the player is on
    public PolygonCollider2D coneCollider;

    private float timer = 0f;
    private float minTime = 3f;
        

    void Update()
    {
        timer += Time.deltaTime;

        // Check for players in the detection area
        if(timer >= minTime)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionDistance, playerLayer);
            foreach (var hitCollider in hitColliders)
            {
                if (IsInCone(hitCollider))
                {
                    EnemyController scriptEnemy = transform.parent.GetComponent<EnemyController>();
                    if (!scriptEnemy.hasPlayerTarget)
                    {
                        timer = 0;
                        scriptEnemy.hasPlayerTarget = true;
                        scriptEnemy.attack.target = hitCollider.transform;
                    }
                }
            }
        }
       
    }

    private bool IsInCone(Collider2D playerCollider)
    {
        // Check if the player's position is within the cone's polygon collider
        return coneCollider.OverlapPoint(playerCollider.transform.position);
    }
}
