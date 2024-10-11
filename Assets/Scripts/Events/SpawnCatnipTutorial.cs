using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCatnipTutorial : MonoBehaviour
{
    public BoxCollider2D holdingPlatform;
    private int maxEventTimes = 1;
    

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int eventTimesCounter = 0;

        if (collision.CompareTag("Player") && eventTimesCounter<maxEventTimes)
        {
            holdingPlatform.isTrigger = true;
            eventTimesCounter++;
        }
    }

    
}
