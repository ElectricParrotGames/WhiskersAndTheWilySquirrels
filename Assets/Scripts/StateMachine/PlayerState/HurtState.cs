using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class HurtState : State
{
    public Transform pocket;
    /// <summary>
    /// Drop percentage only takes values between 0.01 to 0.99
    /// </summary>
    private float dropPercentage = 0.33f;

    public override void Enter()
    {
        ReleaseCatnip();
        isComplete = true;
    }

    public override void Do()
    {


    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }

    private void ReleaseCatnip()
    {
        int catnipCount = pocket.transform.childCount;

        int amountOfCatnipDropped = (int)(pocket.transform.childCount * dropPercentage);

        if (catnipCount < 3)
        {
            amountOfCatnipDropped = catnipCount;
        }

        for (int i = 0; i < amountOfCatnipDropped; i++)
        {
            Vector2 direction = new Vector2((float)Random.Range(-0.5f, 0.5f), (float)Random.Range(1, 2));
            float force = (float)Random.Range(0.5f, 2);

            Transform catnip = pocket.transform.GetChild(i);
            catnip.position = pocket.transform.position;
            catnip.SetParent(null);
            catnip.gameObject.SetActive(true);
            catnip.GetComponent<CatnipScript>().AsReappear();

            Rigidbody2D catnipRb = catnip.GetComponent<Rigidbody2D>();
            catnipRb.velocity = direction * force;
        }
    }
}
