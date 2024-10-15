using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : Detection
{
    public LayerMask groundPlatformMask;
    private readonly float rayLength = 0.15f;
    public Transform fallDetector;
    public bool CanFall { get; private set; }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(fallDetector.position, Vector2.down, rayLength, groundPlatformMask);
        if (hit.collider != null)
        {
            CanFall = true;
        }
        else
        {
            CanFall = false;
        }

        //DebugLine
        Vector2 endPoint = hit.collider ? (Vector2)hit.point : fallDetector.position + Vector3.down * rayLength;
        Debug.DrawLine(fallDetector.position, endPoint, Color.red);
    }
}
