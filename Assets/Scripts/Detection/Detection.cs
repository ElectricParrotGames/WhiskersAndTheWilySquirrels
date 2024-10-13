using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    protected Vector3 position;
    protected Vector3 viewPosition;

    protected void UpdateDetection()
    {
        position = transform.position;
        viewPosition = transform.root.localScale.x > 0 ? Vector2.right : Vector2.left;
    }
}
