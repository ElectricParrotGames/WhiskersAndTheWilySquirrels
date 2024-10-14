using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class WallDetection : Detection
{
    public bool WallDetected { get; private set; }
    public Transform wall;
    public LayerMask groundMask;
    private readonly float rayLength = 0.1f;

    public Transform overHead;
    public bool CanBeJump { get; private set; }

    void Update()
    {
        UpdateDetection();
        DetectWallInFront();
    }

    

    public bool IsTargetBehindWall(Vector3 targetPos)
    {
        Vector3 directionToTarget = (targetPos - position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(position, directionToTarget, Vector2.Distance(position, targetPos), groundMask);
        return hit.collider != null;
    }

    private void DetectWallInFront()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, viewPosition, rayLength, groundMask);
        if (hit.collider != null)
        {
            WallDetected = true;
            wall = hit.transform;

            RaycastHit2D overHeadHit = Physics2D.Raycast(overHead.position, viewPosition, rayLength, groundMask);
            CanBeJump = overHeadHit.collider == null;
        }
        else
        {
            WallDetected = false;
            wall = null;
            CanBeJump = false;
        }

        //DebugLine
        Vector2 endPoint = hit.collider ? (Vector2)hit.point : transform.position + viewPosition * rayLength;
        Debug.DrawLine(transform.position, endPoint, Color.green);
    }

}
