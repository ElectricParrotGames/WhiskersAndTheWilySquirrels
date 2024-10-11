using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornScript : MonoBehaviour
{
    private float rotationSpeed = 540f;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.CompareTag("Ground") || collisionGameObject.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
            return;
        }
        if (collisionGameObject.CompareTag("Player")){
            //the player is hurt
            Destroy(this.gameObject);
        }
    }
}
