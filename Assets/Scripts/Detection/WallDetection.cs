using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class WallDetection : Detection
{
    public bool wallDetected;
    public Transform wall;
    public LayerMask groundMask;
    public float rayLength;

    void Update()
    {
        UpdateDetection();
        Vector3 position = transform.root.localScale.x > 0 ? Vector2.right : Vector2.left; 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, position, rayLength, groundMask);
        if (hit.collider != null)
        {
            wallDetected = true;
            wall = hit.transform;
        }
        else
        {
            wallDetected = false;
            wall = null;
        }
        Vector2 endPoint = hit.collider ? (Vector2)hit.point : transform.position + position * rayLength;

        Debug.Log(wallDetected);
        Debug.DrawLine(transform.position, endPoint, Color.green);
    }

    public bool IsTargetBehindWall(Vector3 targetPos)
    {
        // Create a ray from the player to the target
        Vector3 directionToTarget = (targetPos - position).normalized;

        // Check if the wall is between the player and the target
        RaycastHit2D hit = Physics2D.Raycast(position, directionToTarget, Vector2.Distance(position, targetPos), groundMask);

        // If there is a hit and the wall is hit, then the target is behind the wall
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
