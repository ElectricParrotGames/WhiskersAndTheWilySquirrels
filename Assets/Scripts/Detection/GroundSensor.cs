using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    //public BoxCollider2D groundCheck;
    public LayerMask groundPlatformMask;
    private float rayLength = 0.03f;
    public bool isGrounded { get; private set; }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundPlatformMask);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Vector2 endPoint = hit.collider ? (Vector2)hit.point : transform.position + Vector3.down * rayLength;

        Debug.DrawLine(transform.position, endPoint, Color.gray);
    }
}
