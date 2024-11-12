using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class LevelDoneState : State
{
    AnimatorStateInfo info;
    public override void Enter()
    {
        anim.Play("Sleep");
    }

    public override void Do()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.IsName("Sleep") && info.normalizedTime >= 1.0f)
        {
            PlayerData.instance.life = GetComponentInParent<PlayerController>().lifeManager.LifeTotal;
            GameMaster.instance.FinishLevel();
        }
    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }
}
