using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Core
{
    public Patrol patrol;

    // Start is called before the first frame update
    void Start()
    {
        SetupInstances();
        Set(patrol);
    }

    // Update is called once per frame
    void Update()
    {
        if (state.isComplete)
        {

        }

        state.DoBranch();
    }

    private void FixedUpdate()
    {
        state.FixedDoBranch();
    }
}
