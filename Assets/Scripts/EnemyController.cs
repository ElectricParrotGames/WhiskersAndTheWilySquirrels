using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Core
{
    public Patrol patrol;
    public Collect collect;
    public Hurt hurt;
    public Attack attack;
    public bool isHurt = false;
    public bool hasPlayerTarget = false;

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
            if(state == attack)
            {
                hasPlayerTarget = false;
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
        if (hasPlayerTarget)
        {
            Set(attack);
        }

        if (isHurt)
        {
            Set(hurt,true);
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
        GetComponentInChildren<BoxCollider2D>().gameObject.SetActive(false);
    }

}
