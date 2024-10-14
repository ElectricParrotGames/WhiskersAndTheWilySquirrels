using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatnipDetection : Detection
{
    public LayerMask catnipLayerMask;
    public float catnipRayLength;
    public WallDetection wallDetection;

    public bool IsCatnipAccessible(Vector3 targetCatnip)
    {
        UpdateDetection();
        RaycastHit2D hit = Physics2D.Raycast(position, viewPosition, catnipRayLength, catnipLayerMask);
        
        //DebugLine
        Vector2 endPoint = hit.collider ? (Vector2)hit.point : position + viewPosition * catnipRayLength;
        Debug.DrawLine(position, endPoint, Color.blue);

        return hit.collider != null && !wallDetection.IsTargetBehindWall(targetCatnip);
    }
}
