using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    public int LifeTotal { get; private set; }

    public void SetStartingLife(int life) {
        int maxLife = (int)GameSetting.LifeValue;
        if (life > GameSetting.LifeValue)
        {
            life = maxLife;
        }

        LifeTotal = life;
    }

    public void TakeDamage(int damage)
    {
        LifeTotal -= damage;
    }

    public void GainLife(int healing)
    {
        LifeTotal += healing;
    }

    public bool IsOutOfLives()
    {
        return LifeTotal <= 0;
    }

}
