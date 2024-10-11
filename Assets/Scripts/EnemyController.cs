using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Core
{
    public Patrol patrol;
    public Collect collect;
    public Hurt hurt;
    public bool isHurt = false;

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
            if(state == collect)
            {
                Set(patrol);
            }
        }
        if(state == patrol)
        {
            collect.CheckForTarget();

            if(collect.target != null)
            {
                Set(collect);
            }
        }
        if (isHurt)
        {
            Set(hurt);
        }

        state.DoBranch();
    }

    private void FixedUpdate()
    {
        state.FixedDoBranch();
    }

    public void Hurt()
    {
        isHurt = true;
    }

}
