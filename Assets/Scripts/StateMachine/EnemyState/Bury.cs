using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bury : State
{
    public GameObject dirtPrefab;
    public Transform target;
    private GameObject dirt;

    public override void Enter()
    {
        anim.Play("Bury");
        anim.speed = 0.75f;

        dirt = Instantiate(dirtPrefab, target.position, target.rotation);
        
    }

    public override void Do()
    {
        if(dirt != null && target != null)
        {
            target.SetParent(dirt.transform);
            target.gameObject.SetActive(false);
            target = null;
        }
    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }


}
