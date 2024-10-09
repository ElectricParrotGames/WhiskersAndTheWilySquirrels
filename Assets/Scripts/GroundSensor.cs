using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public LayerMask platformMask;
    public bool isGrounded { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0 || 
            Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, platformMask).Length > 0;
    }
}
