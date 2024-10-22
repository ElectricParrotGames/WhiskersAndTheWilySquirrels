using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private Vector3 offset = new Vector3(0, 0.1f, 0);

    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x+ offset.x, player.position.y, transform.position.z);
    }

}
